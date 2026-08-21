using System.Security.Cryptography;
using System.Text;

namespace MIM.Portal.Application.Common;

public static class VerificationTokenGenerator
{
    public static (string RawToken, string TokenHash) Generate()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        var rawToken = Convert.ToBase64String(bytes)
            .Replace("+", "-")
            .Replace("/", "_")
            .Replace("=", "");

        var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawToken));
        var tokenHash = Convert.ToBase64String(hashBytes);

        return (rawToken, tokenHash);
    }
}
