using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.FetchById;

public sealed record FetchLicenseQuery : IRequest<ContentResponse<FetchLicenseQueryResponse>>
{
    public string? Id { get; set; }
}
