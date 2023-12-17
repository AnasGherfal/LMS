using Common.Wrappers;

namespace Server.Features.Licenses.FetchAll;

public sealed record FetchLicensesQuery : IRequest<PagedResponse<FetchLicensesQueryResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}