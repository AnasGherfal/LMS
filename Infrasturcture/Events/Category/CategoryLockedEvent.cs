using Common.Constants;
using Infrastructure.Events.Abstracts;
using System.Text.Json.Serialization;

namespace Infrastructure.Events.Category;

public class CategoryLockedEvent : EventStore<CategoryLockedEventData>
{
    protected CategoryLockedEvent() { }
    public CategoryLockedEvent(Guid userId, Guid aggregateId, long sequence, CategoryLockedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }

}
public class CategoryLockedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.CategoryLocked;
}

