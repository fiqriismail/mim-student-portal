namespace MIM.Portal.Domain;

public class Token
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public TokenType Type { get; private set; }
    public string TokenHash { get; private set; } = default!;
    public DateTime ExpiresAt { get; private set; }
    public DateTime? ConsumedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Token()
    {
    }

    public static Token Create(Guid userId, TokenType type, string tokenHash, DateTime now, TimeSpan validFor)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("userId is required", nameof(userId));
        }

        if (string.IsNullOrWhiteSpace(tokenHash))
        {
            throw new ArgumentException("tokenHash is required", nameof(tokenHash));
        }

        return new Token
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Type = type,
            TokenHash = tokenHash,
            ExpiresAt = now.Add(validFor),
            CreatedAt = now
        };
    }

    public bool IsValid(DateTime now) => ConsumedAt is null && ExpiresAt > now;
}
