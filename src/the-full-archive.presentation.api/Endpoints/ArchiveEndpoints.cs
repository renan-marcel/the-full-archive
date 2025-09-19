using Microsoft.AspNetCore.Mvc;
using TheFullArchive.Application.Archives.CreateArchive;
using TheFullArchive.Infrastructure;

namespace the_full_archive.presentation.api.Endpoints;

public static class ArchiveEndpoints
{
    public static IEndpointRouteBuilder MapArchiveEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/archives");

        group.MapPost("/", async ([FromServices] CreateArchiveHandler handler, [FromBody] CreateArchiveCommand cmd, CancellationToken ct) =>
        {
            var id = await handler.Handle(cmd, ct);
            return Results.Created($"/archives/{id}", new { id });
        });

        return endpoints;
    }
}
