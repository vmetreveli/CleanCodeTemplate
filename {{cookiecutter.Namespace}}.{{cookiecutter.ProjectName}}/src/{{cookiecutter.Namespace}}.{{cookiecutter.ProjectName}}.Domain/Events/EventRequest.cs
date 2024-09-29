using Newtonsoft.Json;

namespace Cai.Send.Domain.Events;

public sealed class EventRequest
{
    public string EventName { get; set; }

    public long EventId { get; set; }
    public Guid CorrelationId { get; set; }
    public Guid TransactionId { get; set; }
    public string ReturnAddress { get; set; }
    public DateTime ExpiresAt { get; set; }

    [JsonProperty("Body")] public object Body { get; set; }
}