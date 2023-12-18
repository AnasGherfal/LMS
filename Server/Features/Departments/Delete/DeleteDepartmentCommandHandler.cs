using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.Delete;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Department Deleted!",
        };

    }
}
