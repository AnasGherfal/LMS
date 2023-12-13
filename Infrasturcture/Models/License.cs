using Common.Constants;
namespace Infrastructure.Models;

public class License
{
    public Guid Id { get; set; }
    public string SerialKey { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public int NumOfDevices { get; set; }
    public TimeType TimeType { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid ProductId { get; set; }
    public string Contact { get; set; } = default!;
    public ImpactLevel ImpactLevel { get; set; }
    public string? ImpactDescription { get; set; }
    public decimal PriceInUSD { get; set; }
    public decimal PriceInLYD { get; set; }

}
