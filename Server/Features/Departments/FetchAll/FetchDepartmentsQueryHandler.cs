using Bogus;
using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.FetchAll;

public sealed record FetchDepartmentsQueryHandler : IRequestHandler<FetchDepartmentsQuery, PagedResponse<FetchDepartmentsQueryResponse>>
{
    public async Task<PagedResponse<FetchDepartmentsQueryResponse>> Handle(FetchDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var faker = new Faker();
        var mockList = new List<FetchDepartmentsQueryResponse>();
        for (var i = 0; i < 10; i++)
        {
            mockList.Add(new FetchDepartmentsQueryResponse()
            {
                Id = Guid.NewGuid(),
                Icon = faker.Image.PlaceImgUrl(),
                Name = faker.Name.JobType(),
                IsActive = faker.Random.Bool(),
                CreatedOn = faker.Date.Past(),
            });
        }
        return new PagedResponse<FetchDepartmentsQueryResponse>("", mockList, 10);
    }
}
