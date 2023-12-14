using Common.Wrappers;

namespace Server.Features.Products.FetchById;

public sealed record FetchProductQueryHandler : IRequestHandler<FetchProductByIdQuery, ContentResponse<FetchProductByIdQueryResponse>>
{
    public async Task<ContentResponse<FetchProductByIdQueryResponse>> Handle(FetchProductByIdQuery request, CancellationToken cancellationToken)
    {
        return new ContentResponse<FetchProductByIdQueryResponse>("xxxx", new FetchProductByIdQueryResponse()
        {
            CreatedOn = DateTime.UtcNow,
            Description = "Desc",
            Id = Guid.NewGuid(),
            IsActive = true,
            Name = "Softwares"
        });

    }
}
