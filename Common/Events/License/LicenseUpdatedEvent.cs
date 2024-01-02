using Common.Constants;
using Common.Entities.Abstracts;
using System.Text.Json.Serialization;

namespace Common.Events.License;

public class LicenseUpdatedEvent : EventStore<LicenseUpdatedEventData>
{
    protected LicenseUpdatedEvent() { }

    public LicenseUpdatedEvent(string userId, Guid aggregateId, long sequence, LicenseUpdatedEventData data) : base(userId, aggregateId, sequence, data)
    {
    }
}
public class LicenseUpdatedEventData : IEventData
{
    public int? NumOfDevices { get; set; } 
    public string? SerialKey { get; set; }
    public string? Contact { get; set; }
    public DateTime EndOfSupport { get; set; }
    public DateTime EndOfManufacture { get; set; }
    public DateTime EndOfSale { get; set; }
    public ProductType ProductType { get; set; }
    public TimeType? TimeType { get; set; } 
    public ImpactLevel? ImpactLevel { get; set; }
    public DateTime? StartDate { get; set; } 
    public DateTime? ExpireDate { get; set; } 
    public string? ImpactDescription { get; set; } 
    public decimal? PriceInUSD { get; set; }
    public decimal? PriceInLYD { get; set; }
    public int? DepartmentId { get; set; }
    public Guid? ProductId { get; set; }
    [JsonIgnore]
    public EventType Type => EventType.LicenseUpdated;
}
