using MIM.Portal.Domain;
using Xunit;

namespace MIM.Portal.Domain.Tests;

public class StudentProfileTests
{
    [Fact]
    public void Create_sets_all_fields()
    {
        var userId = Guid.NewGuid();
        var now = new DateTime(2026, 8, 21, 10, 0, 0, DateTimeKind.Utc);

        var profile = StudentProfile.Create(userId, "MIM-2026-00001", now);

        Assert.NotEqual(Guid.Empty, profile.Id);
        Assert.Equal(userId, profile.UserId);
        Assert.Equal("MIM-2026-00001", profile.StudentReference);
        Assert.Equal(now, profile.CreatedAt);
        Assert.Equal(now, profile.UpdatedAt);
    }

    [Fact]
    public void Create_rejects_empty_userId()
    {
        Assert.Throws<ArgumentException>(() =>
            StudentProfile.Create(Guid.Empty, "MIM-2026-00001", DateTime.UtcNow));
    }

    [Fact]
    public void Create_rejects_blank_studentReference()
    {
        Assert.Throws<ArgumentException>(() =>
            StudentProfile.Create(Guid.NewGuid(), " ", DateTime.UtcNow));
    }
}
