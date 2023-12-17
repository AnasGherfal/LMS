using Common.Wrappers;

namespace Server.Features.Departments.Create;

public sealed record CreateDepartmentCommand: IRequest<MessageResponse>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
