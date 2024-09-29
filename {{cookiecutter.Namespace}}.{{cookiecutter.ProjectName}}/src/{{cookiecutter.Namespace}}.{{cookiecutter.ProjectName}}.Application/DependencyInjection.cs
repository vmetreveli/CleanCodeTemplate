using Cai.Send.Domain.Events;
using Cai.Send.Infrastructure.Events.DealersPortalTempPasswordEvent;
using Framework.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cai.Send.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddFramework(configuration, typeof(DependencyInjection).Assembly);
        services.AddKeyedScoped<IEvent, DealersPortalTempPasswordEvent>(nameof(DealersPortalTempPasswordEvent));

        return services;
    }
}