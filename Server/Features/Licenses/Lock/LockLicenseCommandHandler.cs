using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Lock;

public sealed record LockLicenseCommandHandler : IRequestHandler<LockLicenseCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(LockLicenseCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg="Category Locked!",
        };
    }
}
