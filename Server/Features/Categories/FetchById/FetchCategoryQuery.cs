using Common.Wrappers;

namespace Server.Features.Categories.FetchById;

public sealed record FetchCategoryQuery : IRequest<ContentResponse<FetchCategoryQueryResponse>>
{
    public string? Id { get; set; }
}
