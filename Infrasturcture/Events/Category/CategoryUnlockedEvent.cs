using Common.Constants;
using Infrastructure.Events.Abstracts;
using System.Text.Json.Serialization;

namespace Infrastructure.Events.Category;

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

