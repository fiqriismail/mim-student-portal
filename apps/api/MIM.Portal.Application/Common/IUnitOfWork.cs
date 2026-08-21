namespace MIM.Portal.Application.Common;

/// <summary>
/// Thin abstraction over an ambient database transaction, so Application-layer handlers
/// can wrap multi-step writes (e.g. Identity user creation + profile/token persistence)
/// atomically without depending on EF Core types directly.
///
/// Usage: begin a transaction, do the work, call <see cref="CommitAsync"/> only if every
/// step succeeded. If the caller never calls <see cref="CommitAsync"/> and disposes the
/// transaction instead (including via an exception unwinding a `using` block), the
/// underlying transaction rolls back, undoing every write made against the ambient
/// scoped DbContext since it was opened.
/// </summary>
public interface IUnitOfWork
{
    Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken);

    Task CommitAsync(IDisposable transaction, CancellationToken cancellationToken);
}
