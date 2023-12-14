using System.Text.Json.Serialization;
using Common.Constants;
using Common.Events.Abstracts;

namespace Common.Events.Category;

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

