using Microsoft.AspNetCore.RateLimiting;
using MIM.Portal.Application.Identity.Register;

namespace MIM.Portal.Api.Endpoints.Identity;

public static class RegisterEndpoint
{
    public static IEndpointRouteBuilder MapRegisterEndpoint(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/identity");

        group.MapPost("/register", async (
            RegisterCommand command,
            RegisterValidator validator,
            RegisterHandler handler,
            CancellationToken cancellationToken) =>
        {
            var validation = await validator.ValidateAsync(command, cancellationToken);
            if (!validation.IsValid)
            {
                return Results.ValidationProblem(validation.ToDictionary());
            }

            var result = await handler.Handle(command, cancellationToken);

            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.Problem(detail: result.ErrorMessage, statusCode: StatusCodes.Status400BadRequest);
        }).RequireRateLimiting("register");

        return app;
    }
}
