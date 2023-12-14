using System.Text.Json.Serialization;
using Common.Constants;
using Common.Events.Abstracts;

namespace Common.Events.Category;

public class CategoryUnlockedEvent : EventStore<CategoryUnlockedEventData>
{
    protected CategoryUnlockedEvent() { }
    public CategoryUnlockedEvent(Guid userId, Guid aggregateId, long sequence, CategoryUnlockedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }

}
public class CategoryUnlockedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.CategoryUnlocked;
}

