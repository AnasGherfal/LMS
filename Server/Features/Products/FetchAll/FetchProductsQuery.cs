using Common.Wrappers;

namespace Server.Features.Products.FetchAll;

public sealed record FetchProductsQuery : IRequest<PagedResponse<FetchProductsQueryResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}