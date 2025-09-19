using Microsoft.Extensions.DependencyInjection;
using TheFullArchive.Shared.Abstractions.Clock;

namespace TheFullArchive.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();
        return services;
    }
}
