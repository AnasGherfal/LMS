using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Product;

public class ProductUpdatedEvent : EventStore<ProductUpdatedEventData>
{
    protected ProductUpdatedEvent() { }
    public ProductUpdatedEvent(string userId, Guid aggregateId, long sequence, ProductUpdatedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }

}
public class ProductUpdatedEventData : IEventData
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Provider { get; set; }
    public Guid? OldFileIdentifier { get; set; }
    public Guid? FileIdentifier { get; set; }
    [JsonIgnore]
    public EventType Type => EventType.ProductUpdated;
}
