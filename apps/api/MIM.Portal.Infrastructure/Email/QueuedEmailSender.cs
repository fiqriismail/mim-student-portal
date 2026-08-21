using System.Threading.Channels;
using MIM.Portal.Application.Common;

namespace MIM.Portal.Infrastructure.Email;

public class QueuedEmailSender(Channel<EmailMessage> channel) : IEmailSender
{
    public async ValueTask Enqueue(EmailMessage message, CancellationToken cancellationToken)
    {
        await channel.Writer.WriteAsync(message, cancellationToken);
    }
}
