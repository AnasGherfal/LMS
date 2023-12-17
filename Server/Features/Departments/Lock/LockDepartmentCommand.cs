using Common.Wrappers;

namespace Server.Features.Departments.Lock;

public sealed record LockDepartmentCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
