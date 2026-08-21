namespace MIM.Portal.Domain;

public class StudentProfile
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string StudentReference { get; private set; } = default!;
    public DateOnly? DateOfBirth { get; private set; }
    public string? NicOrPassport { get; private set; }
    public string? Address { get; private set; }
    public string? HighestQualification { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private StudentProfile()
    {
    }

    public static StudentProfile Create(Guid userId, string studentReference, DateTime now)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("userId is required", nameof(userId));
        }

        if (string.IsNullOrWhiteSpace(studentReference))
        {
            throw new ArgumentException("studentReference is required", nameof(studentReference));
        }

        return new StudentProfile
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            StudentReference = studentReference,
            CreatedAt = now,
            UpdatedAt = now
        };
    }
}
