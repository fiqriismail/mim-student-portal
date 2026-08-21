using MIM.Portal.Domain;

namespace MIM.Portal.Application.Common;

public interface IRegistrationWriter
{
    Task SaveAsync(StudentProfile studentProfile, Token verificationToken, CancellationToken cancellationToken);
}
