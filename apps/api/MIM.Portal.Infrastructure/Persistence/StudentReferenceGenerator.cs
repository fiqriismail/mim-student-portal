using Microsoft.EntityFrameworkCore;
using MIM.Portal.Application.Common;

namespace MIM.Portal.Infrastructure.Persistence;

public class StudentReferenceGenerator(PortalDbContext dbContext) : IStudentReferenceGenerator
{
    public async Task<string> NextAsync(CancellationToken cancellationToken)
    {
        var next = await dbContext.Database
            .SqlQuery<long>($"SELECT nextval('student_reference_seq') AS \"Value\"")
            .FirstAsync(cancellationToken);

        return $"MIM-{DateTime.UtcNow.Year}-{next:D5}";
    }
}
