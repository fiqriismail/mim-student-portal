using System.Threading.Channels;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MIM.Portal.Application.Common;

namespace MIM.Portal.Infrastructure.Email;

public class EmailQueueBackgroundService(
    Channel<EmailMessage> channel,
    ILogger<EmailQueueBackgroundService> logger) : BackgroundService
{
    private const int MaxAttempts = 3;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var message in channel.Reader.ReadAllAsync(stoppingToken))
        {
            await SendWithRetry(message, stoppingToken);
        }
    }

    private async Task SendWithRetry(EmailMessage message, CancellationToken stoppingToken)
    {
        for (var attempt = 1; attempt <= MaxAttempts; attempt++)
        {
            try
            {
                logger.LogInformation(
                    "Sending email to {To} with subject {Subject}: {Body}",
                    message.To, message.Subject, message.HtmlBody);
                return;
            }
            catch (Exception ex) when (attempt < MaxAttempts)
            {
                logger.LogWarning(ex, "Email send attempt {Attempt} failed for {To}, retrying", attempt, message.To);
                await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt)), stoppingToken);
            }
        }
    }
}
