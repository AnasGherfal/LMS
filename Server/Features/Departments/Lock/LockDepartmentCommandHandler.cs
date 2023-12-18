using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.Lock;

public sealed record LockDepartmentCommandHandler : IRequestHandler<LockDepartmentCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(LockDepartmentCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg="Department Locked!",
        };
    }
}
