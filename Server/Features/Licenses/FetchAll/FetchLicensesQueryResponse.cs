using Common.Constants;
using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.FetchAll;
public sealed record FetchLicensesQueryResponse : IRequest<PagedResponse<FetchLicensesQueryResponse>>
{
    public Guid Id { get; set; }
    public ImpactLevel ImpactLevel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime? EndOfSupport { get; set; }
    public DateTime? EndOfManufacture { get; set; }
    public DateTime? EndOfSale { get; set; }
    public ProductType ProductType { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int DepartmentId { get; set; } = default!;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
