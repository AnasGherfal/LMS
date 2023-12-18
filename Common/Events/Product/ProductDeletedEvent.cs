using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Product;

public class ProductDeletedEvent : EventStore<ProductDeletedEventData>
{
    protected ProductDeletedEvent() { }
    public ProductDeletedEvent(string userId, Guid aggregateId, long sequence, ProductDeletedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }
}
public class ProductDeletedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.ProductDeleted;
}