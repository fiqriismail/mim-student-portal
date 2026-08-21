namespace MIM.Portal.Application.Identity.Register;

public record RegisterCommand(
    string FullName,
    string Email,
    string Phone,
    string Password,
    string PasswordConfirmation);
