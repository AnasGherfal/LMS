using Common.Constants;
using Infrastructure.Events.Abstracts;
using System.Text.Json.Serialization;

namespace Infrastructure.Events.Category;

public class CategoryDeletedEvent : EventStore<CategoryDeletedEventData>
{
    protected CategoryDeletedEvent() { }
    public CategoryDeletedEvent(Guid userId, Guid aggregateId, long sequence, CategoryDeletedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }
}
public class CategoryDeletedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.CategoryDeleted;
}
