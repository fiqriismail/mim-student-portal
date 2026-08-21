using System.Net;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MIM.Portal.Application.Identity.Register;
using MIM.Portal.Infrastructure.Persistence;
using Xunit;

namespace MIM.Portal.Api.Tests;

public class RegisterEndpointTests : IClassFixture<RegisterEndpointFactory>, IAsyncLifetime
{
    private readonly RegisterEndpointFactory _factory;
    private readonly HttpClient _client;

    public RegisterEndpointTests(RegisterEndpointFactory factory)
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
    public async Task Register_creates_user_profile_and_token()
    {
        var command = new RegisterCommand("Jane Doe", "jane.register@example.com", "0770000000", "verysecurepassword", "verysecurepassword");

        var response = await _client.PostAsJsonAsync("/identity/register", command);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<PortalDbContext>();
        var user = await db.Users.SingleAsync(u => u.Email == "jane.register@example.com");
        var profile = await db.StudentProfiles.SingleAsync(p => p.UserId == user.Id);
        var token = await db.Tokens.SingleAsync(t => t.UserId == user.Id);

        Assert.StartsWith("MIM-", profile.StudentReference);
        Assert.False(string.IsNullOrWhiteSpace(token.TokenHash));
    }

    [Fact]
    public async Task Duplicate_email_returns_generic_message()
    {
        var command = new RegisterCommand("Jane Doe", "jane.duplicate@example.com", "0770000000", "verysecurepassword", "verysecurepassword");
        await _client.PostAsJsonAsync("/identity/register", command);

        var response = await _client.PostAsJsonAsync("/identity/register", command);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("We couldn't complete registration with these details", body);
    }

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
