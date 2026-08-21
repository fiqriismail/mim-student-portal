namespace MIM.Portal.Application.Common;

public interface IEmailSender
{
    ValueTask Enqueue(EmailMessage message, CancellationToken cancellationToken);
}
