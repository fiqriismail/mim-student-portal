using MIM.Portal.Domain;
using Xunit;

namespace MIM.Portal.Domain.Tests;

public class TokenTests
{
    [Fact]
    public void Create_sets_expiry_from_validFor()
    {
        var userId = Guid.NewGuid();
        var now = new DateTime(2026, 8, 21, 10, 0, 0, DateTimeKind.Utc);

        var token = Token.Create(userId, TokenType.EmailVerification, "hash", now, TimeSpan.FromHours(24));

        Assert.Equal(userId, token.UserId);
        Assert.Equal(TokenType.EmailVerification, token.Type);
        Assert.Equal("hash", token.TokenHash);
        Assert.Equal(now.AddHours(24), token.ExpiresAt);
        Assert.Null(token.ConsumedAt);
    }

    [Fact]
    public void IsValid_true_when_unconsumed_and_unexpired()
    {
        var now = new DateTime(2026, 8, 21, 10, 0, 0, DateTimeKind.Utc);
        var token = Token.Create(Guid.NewGuid(), TokenType.EmailVerification, "hash", now, TimeSpan.FromHours(24));

        Assert.True(token.IsValid(now.AddHours(1)));
    }

    [Fact]
    public void IsValid_false_when_expired()
    {
        var now = new DateTime(2026, 8, 21, 10, 0, 0, DateTimeKind.Utc);
        var token = Token.Create(Guid.NewGuid(), TokenType.EmailVerification, "hash", now, TimeSpan.FromHours(24));

        Assert.False(token.IsValid(now.AddHours(25)));
    }
}
