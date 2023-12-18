using Bogus;
using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.FetchById;

public sealed record FetchDepartmentQueryHandler : IRequestHandler<FetchDepartmentQuery, ContentResponse<FetchDepartmentQueryResponse>>
{
    public async Task<ContentResponse<FetchDepartmentQueryResponse>> Handle(FetchDepartmentQuery request, CancellationToken cancellationToken)
    {
        return new ContentResponse<FetchDepartmentQueryResponse>("xxxx", new FetchDepartmentQueryResponse()
        {
            CreatedOn = DateTime.UtcNow,
            Description = "Desc",
            Id = Guid.NewGuid(),
            IsActive = true,
            Name = "IT",
            Icon = new Faker().Image.PlaceImgUrl(),
        });

    }
}
