using Framework.Abstractions.Events;
using Framework.Abstractions.Primitives;

namespace AsynchronousAdapter.Events.Catalog;

public class CityIntegrationEvent : IntegrationBaseEvent
{
    public required string Name { get; init; }

    // public required int CountryId { get; init; }
    // public int StateId { get; init; }

}