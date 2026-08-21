using MIM.Portal.Application.Common;
using MIM.Portal.Domain;
using MIM.Portal.Infrastructure.Persistence;

namespace MIM.Portal.Infrastructure.Identity;

public class RegistrationWriter(PortalDbContext dbContext) : IRegistrationWriter
{
    public async Task SaveAsync(StudentProfile studentProfile, Token verificationToken, CancellationToken cancellationToken)
    {
        dbContext.StudentProfiles.Add(studentProfile);
        dbContext.Tokens.Add(verificationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
