namespace MIM.Portal.Application.Common;

public interface ICommandHandler<in TCommand, TResult>
{
    Task<Result<TResult>> Handle(TCommand command, CancellationToken cancellationToken);
}
