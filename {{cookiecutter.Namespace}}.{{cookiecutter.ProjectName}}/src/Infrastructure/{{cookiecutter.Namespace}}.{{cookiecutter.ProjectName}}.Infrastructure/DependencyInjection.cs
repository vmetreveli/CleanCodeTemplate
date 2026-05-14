using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.Infrastructure.Context;
using {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.Infrastructure.ExternalServices;


namespace {{cookiecutter.Namespace}}.{{cookiecutter.ProjectName}}.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<DbContext, {{cookiecutter.ProjectName}}DbContext>((sp, options) =>
            {
                options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"))
                    // options =>
                    // {
                    //     options.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    //     options.MigrationsHistoryTable($"__{nameof(NotificationDbContext)}");
                    //
                    //     options.EnableRetryOnFailure(5);
                    //     options.MinBatchSize(1);
                    // })
                    .UseSnakeCaseNamingConvention()
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            });

        //services.AddScoped<IEventRepository, EventRepository>();
        //  services.AddScoped<IEventDictionaryRepository, EventDictionaryRepository>();
        // TODO: Add IUnitOfWork implementation


        services.AddExternalServices(configuration);
        return services;
    }
}