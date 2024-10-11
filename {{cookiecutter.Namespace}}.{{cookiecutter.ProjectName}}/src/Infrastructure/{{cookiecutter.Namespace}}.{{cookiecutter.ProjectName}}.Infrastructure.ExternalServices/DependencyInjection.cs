using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.Infrastructure.ExternalServices;

public static class DependencyInjection
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
    {
       // AddApiClient(services, configuration);
        return services;
    }


    #region  AddCatalogApiClient

  // private static void AddApiClient(IServiceCollection services, IConfiguration configuration)
  // {
  //     var baseAddress = configuration["AppConfiguration:ExternalServices:ApiClient:BaseAddress"];
  //     baseAddress.ThrowIfNullOrEmpty();
  //
  //     services.AddRefitClient<IApiClientService>()
  //         .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseAddress));
  // }
    #endregion
    
    
}