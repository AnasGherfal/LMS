using Bogus;
using Common.Wrappers;

namespace Server.Features.Categories.FetchById;

public sealed record FetchCategoryQueryHandler : IRequestHandler<FetchCategoryQuery, ContentResponse<FetchCategoryQueryResponse>>
{
    public async Task<ContentResponse<FetchCategoryQueryResponse>> Handle(FetchCategoryQuery request, CancellationToken cancellationToken)
    {
        var faker = new Faker();
        return new ContentResponse<FetchCategoryQueryResponse>("xxxx", new FetchCategoryQueryResponse()
        {
            CreatedOn = DateTime.UtcNow,
            Description = "Desc",
            Icon = faker.Image.PlaceImgUrl(),
            Id = Guid.NewGuid(),
            IsActive = true,
            Name = "Softwares"
        });
    }
}
