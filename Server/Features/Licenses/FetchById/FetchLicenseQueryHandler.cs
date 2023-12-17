using Common.Wrappers;

namespace Server.Features.Licenses.FetchById;

public sealed record FetchLicenseQueryHandler : IRequestHandler<FetchLicenseQuery, ContentResponse<FetchLicenseQueryResponse>>
{
    public async Task<ContentResponse<FetchLicenseQueryResponse>> Handle(FetchLicenseQuery request, CancellationToken cancellationToken)
    {
        return new ContentResponse<FetchLicenseQueryResponse>("xxxx", new FetchLicenseQueryResponse()
        {
            CreatedOn = DateTime.UtcNow,
            Description = "Desc",
            Id = Guid.NewGuid(),
            IsActive = true,
            Name = "Softwares"
        });

    }
}
