using Common.Wrappers;

namespace Server.Features.Categories.FetchAll;

public sealed record FetchCategoriesQueryHandler : IRequestHandler<FetchCategoriesQuery, PagedResponse<FetchCategoriesQueryResponse>>
{
    public Task<PagedResponse<FetchCategoriesQueryResponse>> Handle(FetchCategoriesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
