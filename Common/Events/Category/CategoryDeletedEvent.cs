using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Category;

public class CategoryDeletedEvent : EventStore<CategoryDeletedEventData>
{
    protected CategoryDeletedEvent() { }
    public CategoryDeletedEvent(string userId, Guid aggregateId, long sequence, CategoryDeletedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }
}
public class CategoryDeletedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.CategoryDeleted;
}