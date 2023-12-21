using Common.Constants;
using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Create;

public sealed record CreateLicenseCommand: IRequest<MessageResponse>
{
    public int NumOfDevices { get; set; }
    public string? SerialKey { get; set; }
    public string? Contact { get; set; }
    public TimeType? TimeType { get; set; }
    public ImpactLevel? ImpactLevel { get; set; }
    public string? StartDate { get; set; }
    public string? ExpireDate { get; set; }
    public string? ImpactDescription { get; set; }
    public decimal? PriceInUSD { get; set; }
    public decimal? PriceInLYD { get; set; }
    public string? DepartmentId { get; set; }
    public string? ProductId { get; set; }

}
