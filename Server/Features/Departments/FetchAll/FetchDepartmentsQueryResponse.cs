using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.FetchAll;
public sealed record FetchDepartmentsQueryResponse : IRequest<PagedResponse<FetchDepartmentsQueryResponse>>
{
    public Guid Id { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
