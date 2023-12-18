using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Category;

public class CategoryUpdatedEvent : EventStore<CategoryUpdatedEventData>
{
    protected CategoryUpdatedEvent() { }
    public CategoryUpdatedEvent(string userId, Guid aggregateId, long sequence, CategoryUpdatedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }

}
public class CategoryUpdatedEventData : IEventData
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? OldFileIdentifier { get; set; }
    public Guid? FileIdentifier { get; set; }
    [JsonIgnore]
    public EventType Type => EventType.CategoryUpdated;
}
