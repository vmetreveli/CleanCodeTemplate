using Cai.Send.Infrastructure.ExternalServices.Services.CaiprogAdapter;
using Cai.Send.Infrastructure.ExternalServices.Services.Catalog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

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

        services.AddRefitClient<IGlobalDictionaryService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseAddress));
    }

    private static void AddAdapterApiClient(IServiceCollection services, IConfiguration configuration)
    {
        var baseAddress = configuration["AppConfiguration:ExternalServices:CaiprogAdapter:BaseAddress"];
        baseAddress.ThrowIfNullOrEmpty();

        services.AddRefitClient<ICaiprogAdapterService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseAddress));
    }
}