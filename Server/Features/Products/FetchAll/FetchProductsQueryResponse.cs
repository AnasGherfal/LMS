using Common.Wrappers;
using MediatR;

namespace Server.Features.Products.FetchAll;
public sealed record FetchProductsQueryResponse : IRequest<PagedResponse<FetchProductsQueryResponse>>
{
    public Guid Id { get; set; }
    public string Photo { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int NumberOfLicenses { get; set; } = 0;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
