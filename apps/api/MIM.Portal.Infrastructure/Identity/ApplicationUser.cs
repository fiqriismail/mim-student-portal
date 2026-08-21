using Microsoft.AspNetCore.Identity;
using MIM.Portal.Domain;

namespace MIM.Portal.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public UserRole Role { get; set; } = UserRole.Student;
    public UserStatus Status { get; set; } = UserStatus.PendingVerification;
}
