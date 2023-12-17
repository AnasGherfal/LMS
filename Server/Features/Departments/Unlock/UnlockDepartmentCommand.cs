using Common.Wrappers;

namespace Server.Features.Departments.Unlock;

public sealed record UnlockDepartmentCommand :IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
