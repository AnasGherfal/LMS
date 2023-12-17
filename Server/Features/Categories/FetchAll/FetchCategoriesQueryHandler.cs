using Bogus;
using Common.Wrappers;

namespace Server.Features.Categories.FetchAll;

public sealed record FetchCategoriesQueryHandler : IRequestHandler<FetchCategoriesQuery, PagedResponse<FetchCategoriesQueryResponse>>
{
    public async Task<PagedResponse<FetchCategoriesQueryResponse>> Handle(FetchCategoriesQuery request, CancellationToken cancellationToken)
    {
        var faker = new Faker();
        var mockList = new List<FetchCategoriesQueryResponse>();
        for (var i = 0; i < 10; i++)
        {
            mockList.Add(new FetchCategoriesQueryResponse()
                    {
                        Id = Guid.NewGuid(),
                        Icon = faker.Image.PlaceImgUrl(),
                        Name = faker.Name.JobType(),
                        IsActive = faker.Random.Bool(),
                        CreatedOn = faker.Date.Past(),
                    });
        }
        return new PagedResponse<FetchCategoriesQueryResponse>("", mockList, 10);
    }
}
