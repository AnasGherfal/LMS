using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.Create;

public sealed record CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Departments Created ! | "+request.Name+" "+request.Description,
        };
    }
}
