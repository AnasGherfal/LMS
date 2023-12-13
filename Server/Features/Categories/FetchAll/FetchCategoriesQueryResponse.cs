using Common.Wrappers;

namespace Server.Features.Categories.FetchAll;
public sealed record FetchCategoriesQueryResponse : IRequest<PagedResponse<FetchCategoriesQueryResponse>>
{
    public Guid Id { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
