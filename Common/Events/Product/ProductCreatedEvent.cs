using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Product;

public class ProductCreatedEvent : EventStore<ProductCreatedEventData>
{
    protected ProductCreatedEvent() { }

    public ProductCreatedEvent(string userId, Guid aggregateId, ProductCreatedEventData data) : base(userId, aggregateId, 1, data)
    {
    }
}
public class ProductCreatedEventData : IEventData
{
    public Guid CategoryId { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public Guid FileIdentifier { get; set; } = Guid.Empty;
    [JsonIgnore]
    public EventType Type => EventType.ProductCreated;
}