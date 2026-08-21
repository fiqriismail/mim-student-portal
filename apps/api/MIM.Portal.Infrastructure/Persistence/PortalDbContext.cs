using Microsoft.EntityFrameworkCore;

namespace MIM.Portal.Infrastructure.Persistence;

public class PortalDbContext(DbContextOptions<PortalDbContext> options) : DbContext(options)
{
}
