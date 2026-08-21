namespace MIM.Portal.Application.Common;

public record EmailMessage(string To, string Subject, string HtmlBody);
