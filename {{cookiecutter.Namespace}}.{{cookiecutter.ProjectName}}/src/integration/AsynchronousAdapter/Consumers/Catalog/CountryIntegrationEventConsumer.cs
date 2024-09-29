using AsynchronousAdapter.Events.Catalog;
using Framework.Abstractions.Dispatchers;
using Framework.Abstractions.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AsynchronousAdapter.Consumers.Catalog;

public sealed class CountryIntegrationEventConsumer(
    IDispatcher dispatcher,
    ILogger<CountryIntegrationEventConsumer> logger)
    : IEventConsumer<CountryIntegrationEvent>
{
    public async Task Consume(ConsumeContext<CountryIntegrationEvent> context)
    {
        //TODO: Integration TO BE IMPLEMENTED
        var result = context.Message;
        logger.LogInformation("CountryIntegrationEvent received. : {Name}", result.Name);
    }
}