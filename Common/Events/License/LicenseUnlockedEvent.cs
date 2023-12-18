
using Common.Constants;
using Common.Entities.Abstracts;
using System.Text.Json.Serialization;

namespace Common.Events.License;

public class LicenseUnlockedEvent : EventStore<LicenseUnlockedEventData>
{
    protected LicenseUnlockedEvent() { }

    public LicenseUnlockedEvent(string userId, Guid aggregateId,long sequence, LicenseUnlockedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }
}
public class LicenseUnlockedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.LicenseUnlocked;
}

