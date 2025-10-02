using Microsoft.Extensions.DependencyInjection;
using TaskManagement.SignalRHubs.Hubs;

namespace TaskManagement.SignalRHubs;

public static class DependencyInjection
{
    public static IServiceCollection AddSignalRHubs(this IServiceCollection services)
    {
        services.AddSignalR(options =>
        {
            options.EnableDetailedErrors = true;
        });

        return services;
    }
}
