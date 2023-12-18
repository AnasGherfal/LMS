using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Category;

public class CategoryUnlockedEvent : EventStore<CategoryUnlockedEventData>
{
    protected CategoryUnlockedEvent() { }
    public CategoryUnlockedEvent(string userId, Guid aggregateId, long sequence, CategoryUnlockedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }

}
public class CategoryUnlockedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.CategoryUnlocked;
}
