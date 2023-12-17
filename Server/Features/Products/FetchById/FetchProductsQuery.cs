using Common.Wrappers;

namespace Server.Features.Products.FetchById;

public sealed record FetchProductByIdQuery: IRequest<ContentResponse<FetchProductByIdQueryResponse>>
{
    public string? Id { get; set; }
}