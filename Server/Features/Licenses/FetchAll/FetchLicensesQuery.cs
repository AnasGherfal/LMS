using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.FetchAll;

public sealed record FetchLicensesQuery : IRequest<PagedResponse<FetchLicensesQueryResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? ProductId { get; set; }
    public string? DepartmentId { get; set; }
}