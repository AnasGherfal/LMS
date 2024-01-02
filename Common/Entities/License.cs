using Common.Constants;
using Common.Entities.HrEntities;
using Common.Events.License;

namespace Common.Entities;

public class License : Entity
{
    public Guid Id { get; set; }
    public int NumOfDevices { get; set; }
    public string? SerialKey { get; set; }
    public TimeType TimeType { get; set; }
    public ImpactLevel ImpactLevel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime? EndOfSupport { get; set; }
    public DateTime? EndOfManufacture { get; set; }
    public DateTime? EndOfSale { get; set; }
    public ProductType ProductType { get; set; }
    public string? ImpactDescription { get; set; }
    public decimal PriceInUSD { get; set; }
    public decimal PriceInLYD { get; set; }
    public EntityStatus Status { get; set; }
    public int DepartmentId { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public void Apply(LicenseCreatedEvent @event)
    {
        Sequence = @event.Sequence;
        CreatedOn = @event.DateTime;
        UpdatedOn = @event.DateTime;
        Id = @event.AggregateId;
        NumOfDevices = @event.Data.NumOfDevices;
        ImpactDescription = @event.Data.ImpactDescription;
        DepartmentId = @event.Data.DepartmentId;
        ProductType=@event.Data.ProductType;
        EndOfManufacture = @event.Data.EndOfManufacture; 
        EndOfSale = @event.Data.EndOfSale;
        EndOfSupport = @event.Data.EndOfSupport;
        ProductId = @event.Data.ProductId;
        ImpactLevel = @event.Data.ImpactLevel;
        StartDate = @event.Data.StartDate;
        ExpireDate = @event.Data.ExpireDate;
        SerialKey = @event.Data.SerialKey;
        TimeType = @event.Data.TimeType;
        PriceInLYD = @event.Data.PriceInLYD;
        PriceInUSD = @event.Data.PriceInUSD;
        Status = EntityStatus.Active;
    }
    public void Apply(LicenseUpdatedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        NumOfDevices = @event.Data.NumOfDevices ?? NumOfDevices;
        ImpactDescription = @event.Data.ImpactDescription??ImpactDescription;
        DepartmentId = @event.Data.DepartmentId ?? DepartmentId;
        ProductId = @event.Data.ProductId ?? ProductId;
        ProductType = @event.Data.ProductType;
        EndOfManufacture = @event.Data.EndOfManufacture;
        EndOfSale = @event.Data.EndOfSale;
        EndOfSupport = @event.Data.EndOfSupport;
        ImpactLevel = @event.Data.ImpactLevel ?? ImpactLevel;
        StartDate = @event.Data.StartDate ?? StartDate;
        ExpireDate = @event.Data.ExpireDate ?? ExpireDate;
        SerialKey = @event.Data.SerialKey;
        TimeType = @event.Data.TimeType ?? TimeType;
        PriceInLYD = @event.Data.PriceInLYD ?? PriceInLYD;
        PriceInUSD = @event.Data.PriceInUSD ?? PriceInUSD;
    }
    public void Apply(LicenseLockedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        Status = EntityStatus.Locked;
    }
    public void Apply(LicenseUnlockedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        Status = EntityStatus.Active;
    }
    public void Apply(LicenseDeletedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        IsDeleted = true;
    }
}
