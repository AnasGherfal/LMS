using Common.Constants;
using Common.Entities.Abstracts;
using System.Text.Json.Serialization;

namespace Common.Events.License;

public class LicenseLockedEvent : EventStore<LicenseLockedEventData>
{
    protected LicenseLockedEvent() { }

    public LicenseLockedEvent(string userId, Guid aggregateId, long sequence, LicenseLockedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }
}
public class LicenseLockedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.LicenseLocked;
}
