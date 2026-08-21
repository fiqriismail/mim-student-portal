using Microsoft.AspNetCore.Identity;
using MIM.Portal.Infrastructure.Identity;
using Xunit;

namespace MIM.Portal.Infrastructure.Tests.Identity;

public class ArgonPasswordHasherTests
{
    private readonly ArgonPasswordHasher _hasher = new();
    private readonly ApplicationUser _user = new() { Email = "jane@example.com" };

    [Fact]
    public void Correct_password_verifies_successfully()
    {
        var hash = _hasher.HashPassword(_user, "verysecurepassword");

        var result = _hasher.VerifyHashedPassword(_user, hash, "verysecurepassword");

        Assert.Equal(PasswordVerificationResult.Success, result);
    }

    [Fact]
    public void Wrong_password_fails_verification()
    {
        var hash = _hasher.HashPassword(_user, "verysecurepassword");

        var result = _hasher.VerifyHashedPassword(_user, hash, "wrongpassword");

        Assert.Equal(PasswordVerificationResult.Failed, result);
    }

    [Fact]
    public void Hash_never_contains_the_plaintext_password()
    {
        var hash = _hasher.HashPassword(_user, "verysecurepassword");

        Assert.DoesNotContain("verysecurepassword", hash);
    }
}
