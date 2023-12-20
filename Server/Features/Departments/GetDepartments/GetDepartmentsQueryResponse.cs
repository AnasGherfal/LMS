using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.GetDepartments;

public sealed record GetDepartmentsQueryResponse : IRequest<PagedResponse<GetDepartmentsQueryResponse>>
{
    //public Guid Id { get; set; }
    // public string Name { get; set; } = string.Empty;
    public short EntityId { get; set; }
    public string EntityName { get; set; }
}
