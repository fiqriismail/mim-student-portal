using MIM.Portal.Application.Common;
using MIM.Portal.Domain;

namespace MIM.Portal.Application.Identity.Register;

public class RegisterHandler(
    IIdentityService identityService,
    IStudentReferenceGenerator studentReferenceGenerator,
    IRegistrationWriter registrationWriter,
    IEmailSender emailSender,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterCommand, RegisterResponse>
{
    private const string GenericFailureMessage =
        "We couldn't complete registration with these details. If you already have an account, try signing in or resetting your password.";

    public async Task<Result<RegisterResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // The whole flow below (Identity user row through profile/token persistence) runs
        // inside one database transaction. UserManager<ApplicationUser> and
        // RegistrationWriter both ultimately write through the same scoped
        // PortalDbContext, so opening the transaction here before CreateUserAsync makes
        // the user-row insert participate in it too. We only ever call CommitAsync once
        // every downstream step has succeeded; any earlier return, or an exception caught
        // below, leaves the transaction uncommitted so it rolls back on dispose -
        // undoing the Identity user row along with everything else. This is what stops a
        // downstream failure (sequence unavailable, domain guard, unique-index violation)
        // from leaving a permanently-orphaned, permanently-email-blocking user row behind.
        using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);

        var creation = await identityService.CreateUserAsync(
            command.Email, command.Password, command.FullName, command.Phone, cancellationToken);

        if (!creation.Succeeded)
        {
            // Nothing to commit - transaction rolls back (a no-op, since CreateUserAsync
            // itself wrote nothing) when it's disposed at the end of this method.
            return Result<RegisterResponse>.Failure("registration-failed", GenericFailureMessage);
        }

        try
        {
            var now = DateTime.UtcNow;
            var studentReference = await studentReferenceGenerator.NextAsync(cancellationToken);
            var profile = StudentProfile.Create(creation.UserId, studentReference, now);

            var (rawToken, tokenHash) = VerificationTokenGenerator.Generate();
            var token = Token.Create(creation.UserId, TokenType.EmailVerification, tokenHash, now, TimeSpan.FromHours(24));

            await registrationWriter.SaveAsync(profile, token, cancellationToken);

            await unitOfWork.CommitAsync(transaction, cancellationToken);

            // Enqueue only after the transaction has committed, so we never email a
            // verification link for a registration that ended up rolled back.
            await emailSender.Enqueue(
                new EmailMessage(
                    command.Email,
                    "Verify your MIM Student Portal account",
                    $"Click to verify: /verify-email?token={rawToken}"),
                cancellationToken);

            return Result<RegisterResponse>.Success(new RegisterResponse(command.Email));
        }
        catch (Exception)
        {
            // Deliberately caught here rather than left to propagate: the transaction is
            // not committed, so disposing it below rolls back everything written since it
            // was opened (including the Identity user row from CreateUserAsync above).
            // Translating to a Result.Failure keeps this on the same response path as the
            // duplicate-email case instead of surfacing as an unhandled 500.
            return Result<RegisterResponse>.Failure("registration-failed", GenericFailureMessage);
        }
    }
}
