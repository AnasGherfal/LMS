using Common.Wrappers;
using MediatR;

namespace Server.Features.Categories.FetchAll;
public sealed record FetchCategoriesQueryResponse : IRequest<PagedResponse<FetchCategoriesQueryResponse>>
{
    public Guid Id { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int NumberOfCategories { get; set; } = 0;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
