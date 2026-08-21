using FluentValidation.TestHelper;
using MIM.Portal.Application.Identity.Register;
using Xunit;

namespace MIM.Portal.Application.Tests.Identity.Register;

public class RegisterValidatorTests
{
    private readonly RegisterValidator _validator = new();

    [Fact]
    public void Valid_command_passes()
    {
        var command = new RegisterCommand("Jane Doe", "jane@example.com", "0770000000", "verysecurepassword", "verysecurepassword");

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Invalid_email_fails()
    {
        var command = new RegisterCommand("Jane Doe", "not-an-email", "0770000000", "verysecurepassword", "verysecurepassword");

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void Short_password_fails()
    {
        var command = new RegisterCommand("Jane Doe", "jane@example.com", "0770000000", "short1", "short1");

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void Mismatched_confirmation_fails()
    {
        var command = new RegisterCommand("Jane Doe", "jane@example.com", "0770000000", "verysecurepassword", "differentpassword");

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.PasswordConfirmation);
    }
}
