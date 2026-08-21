using System.Security.Cryptography;
using System.Text;
using MIM.Portal.Application.Common;
using Xunit;

namespace MIM.Portal.Application.Tests.Common;

public class VerificationTokenGeneratorTests
{
    [Fact]
    public void Generate_produces_a_hash_matching_sha256_of_the_raw_token()
    {
        var (rawToken, tokenHash) = VerificationTokenGenerator.Generate();

        var expectedHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(rawToken)));

        Assert.Equal(expectedHash, tokenHash);
        Assert.False(string.IsNullOrWhiteSpace(rawToken));
    }

    [Fact]
    public void Generate_produces_different_tokens_each_call()
    {
        var (rawToken1, _) = VerificationTokenGenerator.Generate();
        var (rawToken2, _) = VerificationTokenGenerator.Generate();

        Assert.NotEqual(rawToken1, rawToken2);
    }
}
