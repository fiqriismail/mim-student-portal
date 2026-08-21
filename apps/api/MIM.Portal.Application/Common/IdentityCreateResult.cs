namespace MIM.Portal.Application.Common;

public class IdentityCreateResult
{
    public bool Succeeded { get; }
    public Guid UserId { get; }

    private IdentityCreateResult(bool succeeded, Guid userId)
    {
        Succeeded = succeeded;
        UserId = userId;
    }

    public static IdentityCreateResult Success(Guid userId) => new(true, userId);

    public static IdentityCreateResult Failure() => new(false, Guid.Empty);
}
