using Framework.Abstractions.Primitives;

namespace AsynchronousAdapter.Events.Catalog;

public class CountryIntegrationEvent : IntegrationBaseEvent
{
    public string Name { get; set; }

}