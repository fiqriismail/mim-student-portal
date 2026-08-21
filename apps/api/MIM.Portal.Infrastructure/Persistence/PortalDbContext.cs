using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MIM.Portal.Domain;
using MIM.Portal.Infrastructure.Identity;

namespace MIM.Portal.Infrastructure.Persistence;

public class PortalDbContext(DbContextOptions<PortalDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
    public DbSet<Token> Tokens => Set<Token>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasSequence<long>("student_reference_seq").StartsAt(1);

        builder.ApplyConfigurationsFromAssembly(typeof(PortalDbContext).Assembly);
    }
}
