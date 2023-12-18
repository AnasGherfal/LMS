using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.Unlock;

public sealed record UnlockDepartmentCommand :IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
