using Common.Wrappers;

namespace Server.Features.Departments.Update;

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Department Updated!",
        };
    }
}
