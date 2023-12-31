using Common.Constants;
using Common.Entities.Abstracts;
using System.Text.Json.Serialization;

namespace Common.Events.License;

public class LicenseDeletedEvent : EventStore<LicenseDeletedEventData>
{
    protected LicenseDeletedEvent() { }
    public LicenseDeletedEvent(string userId, Guid aggregateId, long sequence, LicenseDeletedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }
}
public class LicenseDeletedEventData : IEventData
{
    [JsonIgnore]
    public EventType Type => EventType.LicenseDeleted;
}
