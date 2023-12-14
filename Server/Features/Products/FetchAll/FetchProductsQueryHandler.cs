using Common.Wrappers;

namespace Server.Features.Products.FetchAll;

public sealed record FetchProductsQueryHandler : IRequestHandler<FetchProductsQuery, PagedResponse<FetchProductsQueryResponse>>
{
    public async Task<PagedResponse<FetchProductsQueryResponse>> Handle(FetchProductsQuery request, CancellationToken cancellationToken)
    {
        return new PagedResponse<FetchProductsQueryResponse>("", new List<FetchProductsQueryResponse>(), 10);
    }
}
