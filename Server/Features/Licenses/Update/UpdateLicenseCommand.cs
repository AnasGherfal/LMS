using Common.Constants;
using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Update;

public sealed record UpdateLicenseCommand : IRequest<MessageResponse>
{
    public string? Id { get; private set; }
    public int NumOfDevices { get; set; }
    public string? SerialKey { get; set; }
    public TimeType TimeType { get; set; }
    public string Contact { get; set; } = string.Empty;
    public ImpactLevel ImpactLevel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public string? ImpactDescription { get; set; }
    public decimal PriceInUSD { get; set; }
    public decimal PriceInLYD { get; set; }
    public void SetId(string id)
    {
        Id = id;
    }

}
