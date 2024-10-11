using Framework.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddFramework(configuration, typeof(DependencyInjection).Assembly);

        return services;
    }
}