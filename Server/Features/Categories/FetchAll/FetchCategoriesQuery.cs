using Common.Wrappers;
using MediatR;

namespace Server.Features.Categories.FetchAll;

public sealed record FetchCategoriesQuery : IRequest<PagedResponse<FetchCategoriesQueryResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? Search { get; set; }
}