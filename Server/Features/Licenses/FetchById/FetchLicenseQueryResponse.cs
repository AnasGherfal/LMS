using Common.Constants;

namespace Server.Features.Licenses.FetchById;

public sealed record FetchLicenseQueryResponse 
{
    public Guid Id { get; set; }
    public int NumOfDevices { get; set; }
    public string? SerialKey { get; set; }
    public TimeType TimeType { get; set; }
    public ImpactLevel ImpactLevel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public string? ImpactDescription { get; set; }
    public decimal PriceInUSD { get; set; }
    public decimal PriceInLYD { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public short? DepartmentId  { get; set; }= default!;
    public Guid? ProductId { get; set; } = Guid.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
