using Common.Wrappers;
using MediatR;

namespace Server.Features.LookUps.FetchDepartments;

public sealed record FetchDepartmentsQueryResponse : IRequest<PagedResponse<FetchDepartmentsQueryResponse>>
{
    public short Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OwnerName { get; set; }
}
