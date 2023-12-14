using Common.Constants;
using Infrastructure.Events.Abstracts;
using System.Text.Json.Serialization;

namespace Infrastructure.Events.Category;

public class CategoryUpdatedEvent : EventStore<CategoryUpdatedEventData>
{
    protected CategoryUpdatedEvent() { }
    public CategoryUpdatedEvent(Guid userId, Guid aggregateId, long sequence, CategoryUpdatedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }

}
public class CategoryUpdatedEventData : IEventData
{

    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    [JsonIgnore]
    public EventType Type => EventType.CategoryUpdated;
}

