using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Product;

public class ProductUnlockedEvent : EventStore<ProductUnlockedEventData>
{
    protected ProductUnlockedEvent() { }
    public ProductUnlockedEvent(string userId, Guid aggregateId, long sequence, ProductUnlockedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }

}
public class ProductUnlockedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.ProductUnlocked;
}
