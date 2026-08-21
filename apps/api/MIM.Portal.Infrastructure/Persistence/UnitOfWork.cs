using Microsoft.EntityFrameworkCore.Storage;
using MIM.Portal.Application.Common;

namespace MIM.Portal.Infrastructure.Persistence;

public class UnitOfWork(PortalDbContext dbContext) : IUnitOfWork
{
    public async Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken) =>
        await dbContext.Database.BeginTransactionAsync(cancellationToken);

    public async Task CommitAsync(IDisposable transaction, CancellationToken cancellationToken)
    {
        if (transaction is not IDbContextTransaction dbTransaction)
        {
            throw new InvalidOperationException(
                $"Expected a transaction created by {nameof(UnitOfWork)}.{nameof(BeginTransactionAsync)}.");
        }

        await dbTransaction.CommitAsync(cancellationToken);
    }
}
