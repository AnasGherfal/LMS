using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Update;

public class UpdateLicenseCommandHandler : IRequestHandler<UpdateLicenseCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(UpdateLicenseCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Category Updated!",
        };
    }
}
