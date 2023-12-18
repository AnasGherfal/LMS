
using Common.Constants;
using Common.Entities.Abstracts;
using System.Text.Json.Serialization;

namespace Common.Events.License;

public class LicenseCreatedEvent : EventStore<LicenseCreatedEventData>
{
    protected LicenseCreatedEvent() { }

    public LicenseCreatedEvent(string userId, Guid aggregateId, LicenseCreatedEventData data) : base(userId, aggregateId, 1, data)
    {
    }
}
public class LicenseCreatedEventData : IEventData
{
    public int NumOfDevices { get; set; } = default!;
    public string SerialKey { get; set; } = string.Empty;
    public TimeType TimeType { get; set; }= default!;
    public string Contact { get; set; } = string.Empty;
    public ImpactLevel ImpactLevel { get; set; } = default!;
    public DateTime StartDate { get; set; } = default!;
    public DateTime ExpireDate { get; set; } = default!;
    public string ImpactDescription { get; set; }=string.Empty;
    public decimal PriceInUSD { get; set; } = default!;
    public decimal PriceInLYD { get; set; } = default!;
    public Guid DepartmentId { get; set; } = Guid.Empty;
    public Guid ProductId { get; set; }= Guid.Empty;
    [JsonIgnore]
    public EventType Type => EventType.LicenseCreated;
}
