using Common.Wrappers;

namespace Server.Features.Categories.FetchAll;

public sealed record FetchCategoriesQuery : IRequest<PagedResponse<FetchCategoriesQueryResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}