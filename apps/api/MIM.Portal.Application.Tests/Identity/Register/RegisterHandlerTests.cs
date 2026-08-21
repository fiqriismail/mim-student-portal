using MIM.Portal.Application.Common;
using MIM.Portal.Application.Identity.Register;
using MIM.Portal.Domain;
using Moq;
using Xunit;

namespace MIM.Portal.Application.Tests.Identity.Register;

public class RegisterHandlerTests
{
    private readonly Mock<IIdentityService> _identityService = new();
    private readonly Mock<IStudentReferenceGenerator> _referenceGenerator = new();
    private readonly Mock<IRegistrationWriter> _registrationWriter = new();
    private readonly Mock<IEmailSender> _emailSender = new();
    private readonly RegisterHandler _handler;

    public RegisterHandlerTests()
    {
        _handler = new RegisterHandler(
            _identityService.Object,
            _referenceGenerator.Object,
            _registrationWriter.Object,
            _emailSender.Object);
    }

    [Fact]
    public async Task Successful_registration_creates_profile_token_and_enqueues_email()
    {
        var userId = Guid.NewGuid();
        _identityService
            .Setup(s => s.CreateUserAsync("jane@example.com", "verysecurepassword", "Jane Doe", "0770000000", It.IsAny<CancellationToken>()))
            .ReturnsAsync(IdentityCreateResult.Success(userId));
        _referenceGenerator
            .Setup(g => g.NextAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync("MIM-2026-00001");

        var command = new RegisterCommand("Jane Doe", "jane@example.com", "0770000000", "verysecurepassword", "verysecurepassword");

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.Equal("jane@example.com", result.Value!.Email);
        _registrationWriter.Verify(
            w => w.SaveAsync(
                It.Is<StudentProfile>(p => p.UserId == userId && p.StudentReference == "MIM-2026-00001"),
                It.Is<Token>(t => t.UserId == userId && t.Type == TokenType.EmailVerification),
                It.IsAny<CancellationToken>()),
            Times.Once);
        _emailSender.Verify(
            e => e.Enqueue(It.Is<EmailMessage>(m => m.To == "jane@example.com"), It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Failed_user_creation_returns_generic_message_without_touching_profile_or_email()
    {
        _identityService
            .Setup(s => s.CreateUserAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(IdentityCreateResult.Failure());

        var command = new RegisterCommand("Jane Doe", "jane@example.com", "0770000000", "verysecurepassword", "verysecurepassword");

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.Equal("registration-failed", result.ErrorCode);
        Assert.Equal(
            "We couldn't complete registration with these details. If you already have an account, try signing in or resetting your password.",
            result.ErrorMessage);
        _registrationWriter.Verify(
            w => w.SaveAsync(It.IsAny<StudentProfile>(), It.IsAny<Token>(), It.IsAny<CancellationToken>()),
            Times.Never);
        _emailSender.Verify(
            e => e.Enqueue(It.IsAny<EmailMessage>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }
}
