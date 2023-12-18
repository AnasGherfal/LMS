using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Category;

public class CategoryLockedEvent : EventStore<CategoryLockedEventData>
{
    protected CategoryLockedEvent() { }
    public CategoryLockedEvent(string userId, Guid aggregateId, long sequence, CategoryLockedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }

}

public class CategoryLockedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.CategoryLocked;
}
