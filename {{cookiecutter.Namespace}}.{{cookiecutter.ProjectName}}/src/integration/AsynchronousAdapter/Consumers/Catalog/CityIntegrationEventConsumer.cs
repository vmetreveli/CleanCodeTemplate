using AsynchronousAdapter.Events.Catalog;
using Framework.Abstractions.Dispatchers;
using Framework.Abstractions.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AsynchronousAdapter.Consumers.Catalog;

public sealed class CityIntegrationEventConsumer(IDispatcher dispatcher, ILogger<CityIntegrationEventConsumer> logger)
    : IEventConsumer<CityIntegrationEvent>
{
    public async Task Consume(ConsumeContext<CityIntegrationEvent> context)
    {
        //TODO: Integration TO BE IMPLEMENTED
        var result = context.Message;
        logger.LogInformation("CityIntegrationEvent received. : {Name}", result.Name);
    }
}