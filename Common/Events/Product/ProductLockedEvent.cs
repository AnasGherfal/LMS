using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Product;

public class ProductLockedEvent : EventStore<ProductLockedEventData>
{
    protected ProductLockedEvent() { }
    public ProductLockedEvent(string userId, Guid aggregateId, long sequence, ProductLockedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }

}

public class ProductLockedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.ProductLocked;
}
