using Common.Constants;
using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.FetchAll;
public sealed record FetchLicensesQueryResponse : IRequest<PagedResponse<FetchLicensesQueryResponse>>
{
    public Guid Id { get; set; }
    public string Contact { get; set; } = string.Empty;
    public ImpactLevel ImpactLevel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string DepartmentName { get; set; }= string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
