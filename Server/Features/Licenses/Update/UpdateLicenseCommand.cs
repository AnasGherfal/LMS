using Common.Constants;
using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Update;

public sealed record UpdateLicenseCommand : IRequest<MessageResponse>
{
    public string? Id { get; private set; }
    public int? NumOfDevices { get; set; }
    public string? SerialKey { get; set; }
    public TimeType? TimeType { get; set; }
    public ImpactLevel? ImpactLevel { get; set; }
    public string? EndOfSupport { get; set; }
    public string? EndOfManufacture { get; set; }
    public string? EndOfSale { get; set; }
    public ProductType ProductType { get; set; }
    public string? StartDate { get; set; }
    public string? ExpireDate { get; set; }
    public string? ImpactDescription { get; set; }
    public decimal? PriceInUSD { get; set; }
    public int? DepartmentId { get; set; }
    public decimal? PriceInLYD { get; set; }
    public void SetId(string id)
    {
        Id = id;
    }

}
