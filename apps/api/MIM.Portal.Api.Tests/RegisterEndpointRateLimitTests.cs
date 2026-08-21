using System.Net;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MIM.Portal.Application.Identity.Register;
using MIM.Portal.Infrastructure.Persistence;
using Xunit;

namespace MIM.Portal.Api.Tests;

public class RegisterEndpointRateLimitTests : IClassFixture<RegisterEndpointFactory>, IAsyncLifetime
{
    private readonly RegisterEndpointFactory _factory;
    private readonly HttpClient _client;

    public RegisterEndpointRateLimitTests(RegisterEndpointFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    public async Task InitializeAsync()
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PortalDbContext>();
        await db.Database.MigrateAsync();
        db.Tokens.RemoveRange(db.Tokens);
        db.StudentProfiles.RemoveRange(db.StudentProfiles);
        db.Users.RemoveRange(db.Users);
        await db.SaveChangesAsync();
    }

    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task Sixth_registration_attempt_in_an_hour_is_rate_limited()
    {
        for (var i = 0; i < 5; i++)
        {
            var command = new RegisterCommand("Jane Doe", $"jane.ratelimit{i}@example.com", "0770000000", "verysecurepassword", "verysecurepassword");
            await _client.PostAsJsonAsync("/identity/register", command);
        }

        var sixth = new RegisterCommand("Jane Doe", "jane.ratelimit5@example.com", "0770000000", "verysecurepassword", "verysecurepassword");
        var response = await _client.PostAsJsonAsync("/identity/register", sixth);

        Assert.Equal(HttpStatusCode.TooManyRequests, response.StatusCode);
    }
}
