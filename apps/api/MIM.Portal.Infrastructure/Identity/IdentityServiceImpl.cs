using Microsoft.AspNetCore.Identity;
using MIM.Portal.Application.Common;
using MIM.Portal.Domain;

namespace MIM.Portal.Infrastructure.Identity;

public class IdentityServiceImpl(UserManager<ApplicationUser> userManager) : IIdentityService
{
    public async Task<IdentityCreateResult> CreateUserAsync(
        string email,
        string password,
        string fullName,
        string phone,
        CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            UserName = email,
            Email = email,
            FullName = fullName,
            Phone = phone,
            Role = UserRole.Student,
            Status = UserStatus.PendingVerification
        };

        var result = await userManager.CreateAsync(user, password);

        return result.Succeeded
            ? IdentityCreateResult.Success(user.Id)
            : IdentityCreateResult.Failure();
    }
}
