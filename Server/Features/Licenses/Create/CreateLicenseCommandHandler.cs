using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Create;

public sealed record CreateLicenseCommandHandler : IRequestHandler<CreateLicenseCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
    {

        return new MessageResponse()
        {
            Msg = "License Created ! | "+request.Name+" "+request.Description,
        };

    }
}
