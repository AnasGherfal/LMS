using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.Unlock;

public sealed record UnlockDepartmentCommandHandler : IRequestHandler<UnlockDepartmentCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(UnlockDepartmentCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Department Unlocked!",
        };
    }
}
