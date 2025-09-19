using Microsoft.Extensions.DependencyInjection;
using TheFullArchive.Application.Abstractions.Persistence;
using TheFullArchive.Application.Archives.CreateArchive;
using TheFullArchive.Infrastructure.Persistence.InMemory;

namespace TheFullArchive.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // For now, wire up in-memory persistence
        services.AddSingleton<IUnitOfWork, InMemoryUnitOfWork>();
        services.AddSingleton<IArchiveRepository, InMemoryArchiveRepository>();
        return services;
    }
}
