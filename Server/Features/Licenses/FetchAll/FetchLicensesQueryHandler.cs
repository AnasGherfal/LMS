using Common.Wrappers;

namespace Server.Features.Licenses.FetchAll;

public sealed record FetchLicensesQueryHandler : IRequestHandler<FetchLicensesQuery, PagedResponse<FetchLicensesQueryResponse>>
{
    public async Task<PagedResponse<FetchLicensesQueryResponse>> Handle(FetchLicensesQuery request, CancellationToken cancellationToken)
    {
        return new PagedResponse<FetchLicensesQueryResponse>("", new List<FetchLicensesQueryResponse>(), 10);
    }
}
