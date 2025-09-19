using Microsoft.AspNetCore.Mvc;

namespace TheFullArchive.Presentation.Api.Endpoints;

public static class WeatherForecastEndpoints
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static IEndpointRouteBuilder MapWeatherForecastEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/weatherforecast");

        group.MapGet("/", () =>
        {
            var results = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Results.Ok(results);
        })
        .WithName("GetWeatherForecast");

        return endpoints;
    }
}
