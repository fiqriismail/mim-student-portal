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

        // ASP.NET Core Identity's own OnModelCreating calls ToTable(...) explicitly for
        // each Identity entity (e.g. "AspNetUsers"), which locks in that table name as
        // explicitly configured. EFCore.NamingConventions' snake_case convention only
        // applies to names derived by convention, so it never touches these — they must
        // be explicitly renamed here to get asp_net_users, asp_net_roles, etc.
        builder.Entity<ApplicationUser>().ToTable("asp_net_users");
        builder.Entity<IdentityRole<Guid>>().ToTable("asp_net_roles");
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("asp_net_user_claims");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("asp_net_user_roles");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("asp_net_user_logins");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("asp_net_role_claims");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("asp_net_user_tokens");

        // ARCHITECTURE.md §7.2 requires the case-insensitive unique-email constraint to be
        // enforced at the database level, not only in application code. Identity's default
        // EmailIndex (on normalized_email) is non-unique; today's accidental backstop is
        // that IdentityServiceImpl sets UserName = email, so the *unique* UserNameIndex
        // happens to also block duplicate emails. That's fragile - any future story that
        // sets UserName to something else (a handle, a student reference, ...) would
        // silently remove email-uniqueness enforcement. Make it explicit and independent
        // of UserName.
        builder.Entity<ApplicationUser>().HasIndex(u => u.NormalizedEmail).IsUnique();

        builder.HasSequence<long>("student_reference_seq").StartsAt(1);

        builder.ApplyConfigurationsFromAssembly(typeof(PortalDbContext).Assembly);
    }
}
