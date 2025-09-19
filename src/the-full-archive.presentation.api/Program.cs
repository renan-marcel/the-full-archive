using Serilog;
using TheFullArchive.application;
using TheFullArchive.Infrastructure;
using TheFullArchive.Presentation.Api.Endpoints;
using TheFullArchive.Presentation.Api.Extensions;
using TheFullArchive.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));


builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Swashbuckle registrations
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

WebApplication app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Minimal API endpoints
app.MapWeatherForecastEndpoints();

await app.RunAsync();
