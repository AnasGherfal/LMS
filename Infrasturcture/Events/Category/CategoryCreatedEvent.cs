using System.Text.Json.Serialization;
using Common.Constants;
using Infrastructure.Events.Abstracts;

namespace Core.Events.Category;

public class CategoryCreatedEvent : EventStore<CategoryCreatedEventData>
{
    protected CategoryCreatedEvent() { }

    public CategoryCreatedEvent(Guid userId, Guid aggregateId, CategoryCreatedEventData data) : base(userId, aggregateId, 1, data)
    {
    }
}
public class CategoryCreatedEventData : IEventData
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public FileStorageData Icon { get; set; } = new();
    [JsonIgnore]
    public EventType Type => EventType.CategoryCreated;
}