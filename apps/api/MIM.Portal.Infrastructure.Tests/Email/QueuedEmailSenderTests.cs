using System.Threading.Channels;
using MIM.Portal.Application.Common;
using MIM.Portal.Infrastructure.Email;
using Xunit;

namespace MIM.Portal.Infrastructure.Tests.Email;

public class QueuedEmailSenderTests
{
    [Fact]
    public async Task Enqueue_writes_the_message_to_the_channel()
    {
        var channel = Channel.CreateUnbounded<EmailMessage>();
        var sender = new QueuedEmailSender(channel);
        var message = new EmailMessage("jane@example.com", "Subject", "Body");

        await sender.Enqueue(message, CancellationToken.None);

        var read = await channel.Reader.ReadAsync();
        Assert.Equal(message, read);
    }
}
