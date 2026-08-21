using MIM.Portal.Application.Common;
using MIM.Portal.Domain;

namespace MIM.Portal.Application.Identity.Register;

public class RegisterHandler(
    IIdentityService identityService,
    IStudentReferenceGenerator studentReferenceGenerator,
    IRegistrationWriter registrationWriter,
    IEmailSender emailSender)
    : ICommandHandler<RegisterCommand, RegisterResponse>
{
    private const string GenericFailureMessage =
        "We couldn't complete registration with these details. If you already have an account, try signing in or resetting your password.";

    public async Task<Result<RegisterResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var creation = await identityService.CreateUserAsync(
            command.Email, command.Password, command.FullName, command.Phone, cancellationToken);

        if (!creation.Succeeded)
        {
            return Result<RegisterResponse>.Failure("registration-failed", GenericFailureMessage);
        }

        var now = DateTime.UtcNow;
        var studentReference = await studentReferenceGenerator.NextAsync(cancellationToken);
        var profile = StudentProfile.Create(creation.UserId, studentReference, now);

        var (rawToken, tokenHash) = VerificationTokenGenerator.Generate();
        var token = Token.Create(creation.UserId, TokenType.EmailVerification, tokenHash, now, TimeSpan.FromHours(24));

        await registrationWriter.SaveAsync(profile, token, cancellationToken);

        await emailSender.Enqueue(
            new EmailMessage(
                command.Email,
                "Verify your MIM Student Portal account",
                $"Click to verify: /verify-email?token={rawToken}"),
            cancellationToken);

        return Result<RegisterResponse>.Success(new RegisterResponse(command.Email));
    }
}
