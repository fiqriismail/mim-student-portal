namespace MIM.Portal.Application.Common;

public interface IIdentityService
{
    Task<IdentityCreateResult> CreateUserAsync(
        string email,
        string password,
        string fullName,
        string phone,
        CancellationToken cancellationToken);
}
