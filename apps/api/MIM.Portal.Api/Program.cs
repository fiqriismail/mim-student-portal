using System.Net;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.HttpOverrides;
using MIM.Portal.Api.Endpoints.Identity;
using MIM.Portal.Application.Identity.Register;
using MIM.Portal.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<RegisterValidator>();
builder.Services.AddScoped<RegisterHandler>();

builder.Services.AddRateLimiter(options =>
{
    options.OnRejected = async (context, cancellationToken) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        await context.HttpContext.Response.WriteAsJsonAsync(
            new { message = "Too many requests. Please try again later." },
            cancellationToken);
    };

    options.AddPolicy("register", httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromHours(1),
                QueueLimit = 0
            }));
});

var app = builder.Build();

// Finding 4: the rate limiter below partitions on httpContext.Connection.RemoteIpAddress.
// Behind any reverse proxy/load balancer/CDN that address is the proxy's, not the
// client's, so every registrant would collapse into one shared partition. Forwarded
// headers middleware rewrites Connection.RemoteIpAddress from X-Forwarded-For/-Proto,
// but ONLY for requests arriving from an address in KnownProxies/KnownNetworks - and
// those two lists are deliberately left empty here (not ASP.NET's built-in
// loopback-only default) so forwarded headers are trusted from nowhere until a real
// deployment explicitly configures its actual proxy IP(s)/CIDR ranges via
// "ForwardedHeaders:KnownProxies" / "ForwardedHeaders:KnownNetworks". Trusting
// X-Forwarded-For unconditionally would make the limiter trivially spoofable by any
// client. AD-1 (hosting target) is still open per ARCHITECTURE.md §11; wire the real
// proxy's address(es) into configuration once that's decided.
var forwardedHeadersOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
forwardedHeadersOptions.KnownProxies.Clear();
forwardedHeadersOptions.KnownIPNetworks.Clear();

foreach (var proxy in builder.Configuration.GetSection("ForwardedHeaders:KnownProxies").Get<string[]>() ?? [])
{
    if (IPAddress.TryParse(proxy, out var address))
    {
        forwardedHeadersOptions.KnownProxies.Add(address);
    }
}

foreach (var network in builder.Configuration.GetSection("ForwardedHeaders:KnownNetworks").Get<string[]>() ?? [])
{
    if (System.Net.IPNetwork.TryParse(network, out var ipNetwork))
    {
        forwardedHeadersOptions.KnownIPNetworks.Add(ipNetwork);
    }
}

app.UseForwardedHeaders(forwardedHeadersOptions);
app.UseRateLimiter();

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));
app.MapRegisterEndpoint();

app.Run();

public partial class Program
{
}
