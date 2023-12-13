using Common.Wrappers;

namespace Server.Features.Categories.FetchAll;

public sealed record FetchCategoriesQueryHandler : IRequestHandler<FetchCategoriesQuery, PagedResponse<FetchCategoriesQueryResponse>>
{
    public async Task<PagedResponse<FetchCategoriesQueryResponse>> Handle(FetchCategoriesQuery request, CancellationToken cancellationToken)
    {
        return new PagedResponse<FetchCategoriesQueryResponse>("", new List<FetchCategoriesQueryResponse>(), 10);
    }
}
