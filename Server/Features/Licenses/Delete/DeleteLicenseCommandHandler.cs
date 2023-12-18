using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Delete;

public class DeleteLicenseCommandHandler : IRequestHandler<DeleteLicenseCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(DeleteLicenseCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Category Deleted!",
        };

    }
}
