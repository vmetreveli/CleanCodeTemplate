using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cai.Send.Infrastructure.ExternalServices;

public static class DependencyInjection
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddCatalogApiClient(services, configuration);
        AddAdapterApiClient(services, configuration);
        return services;
    }


    private static void AddCatalogApiClient(IServiceCollection services, IConfiguration configuration)
    {
        var baseAddress = configuration["AppConfiguration:ExternalServices:CatalogApi:BaseAddress"];
        baseAddress.ThrowIfNullOrEmpty();

        HttpClientBuilderExtensions.ConfigureHttpClient(services.AddRefitClient<IGlobalDictionaryService>(),
            c => c.BaseAddress = new Uri(baseAddress));
    }

    private static void AddAdapterApiClient(IServiceCollection services, IConfiguration configuration)
    {
        var baseAddress = configuration["AppConfiguration:ExternalServices:CaiprogAdapter:BaseAddress"];
        baseAddress.ThrowIfNullOrEmpty();

        HttpClientBuilderExtensions.ConfigureHttpClient(services.AddRefitClient<ICaiprogAdapterService>(),
            c => c.BaseAddress = new Uri(baseAddress));
    }
}