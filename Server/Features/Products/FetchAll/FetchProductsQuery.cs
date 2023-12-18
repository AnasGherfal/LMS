using Common.Wrappers;
using MediatR;

namespace Server.Features.Products.FetchAll;

public sealed record FetchProductsQuery : IRequest<PagedResponse<FetchProductsQueryResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Search { get; set; }
    public string? CategoryId { get; set; }
}