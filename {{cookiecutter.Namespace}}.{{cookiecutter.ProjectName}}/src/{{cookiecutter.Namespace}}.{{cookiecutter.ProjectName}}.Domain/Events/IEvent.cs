using Cai.Send.Domain.Entities.Events;

namespace Cai.Send.Domain.Events;

public interface IEvent
{
    Task<Event> EnrichEvent(EventRequest request);
}