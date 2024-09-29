using Microsoft.Extensions.DependencyInjection;

namespace AsynchronousAdapter;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogIntegration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}