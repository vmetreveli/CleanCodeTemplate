using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.AsynchronousAdapter;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogIntegration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}