namespace MIM.Portal.Application.Common;

public interface IStudentReferenceGenerator
{
    Task<string> NextAsync(CancellationToken cancellationToken);
}
