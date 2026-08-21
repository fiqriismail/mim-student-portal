using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIM.Portal.Domain;

namespace MIM.Portal.Infrastructure.Persistence.Configurations;

public class StudentProfileConfiguration : IEntityTypeConfiguration<StudentProfile>
{
    public void Configure(EntityTypeBuilder<StudentProfile> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.StudentReference).IsRequired().HasMaxLength(20);
        builder.HasIndex(p => p.StudentReference).IsUnique();
        builder.HasIndex(p => p.UserId).IsUnique();
    }
}
