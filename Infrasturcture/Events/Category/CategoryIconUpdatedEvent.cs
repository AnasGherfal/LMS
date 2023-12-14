using Common.Constants;
using Infrastructure.Events.Abstracts;
using System.Text.Json.Serialization;

namespace Infrastructure.Events.Category;

public class CategoryIconUpdatedEvent : EventStore<CategoryIconUpdatedEventData>
{
    protected CategoryIconUpdatedEvent() { }

    public CategoryIconUpdatedEvent(Guid userId, Guid aggregateId, long sequence, CategoryIconUpdatedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }
}

public class CategoryIconUpdatedEventData : IEventData
{
    public Guid? OldFileIdentifier { get; set; }
    public Guid FileIdentifier { get; set; } = Guid.Empty;
    public IconType IconType { get; set; } = IconType.CategoryIcon;
    public string FileLink { get; set; } = string.Empty;
    [JsonIgnore]
    public EventType Type => EventType.CategoryIconUpdated;
}