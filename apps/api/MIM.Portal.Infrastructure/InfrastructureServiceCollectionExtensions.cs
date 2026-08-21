using System.Threading.Channels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MIM.Portal.Application.Common;
using MIM.Portal.Infrastructure.Email;
using MIM.Portal.Infrastructure.Identity;
using MIM.Portal.Infrastructure.Persistence;

namespace MIM.Portal.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PortalDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Portal"))
                .UseSnakeCaseNamingConvention());

        services
            .AddIdentityCore<ApplicationUser>(options =>
            {
                // AC-1.1.3: length only, no other complexity rule.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 0;

                // AC-1.1.2: case-insensitive unique email. Identity normalizes email to
                // NormalizedEmail (uppercased) and enforces uniqueness against it only
                // when this is explicitly turned on — it defaults to false.
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<PortalDbContext>();

        services.AddScoped<IPasswordHasher<ApplicationUser>, ArgonPasswordHasher>();
        services.AddScoped<IIdentityService, IdentityServiceImpl>();
        services.AddScoped<IStudentReferenceGenerator, StudentReferenceGenerator>();
        services.AddScoped<IRegistrationWriter, RegistrationWriter>();

        services.AddSingleton(Channel.CreateUnbounded<EmailMessage>());
        services.AddSingleton<IEmailSender, QueuedEmailSender>();
        services.AddHostedService<EmailQueueBackgroundService>();

        return services;
    }
}
