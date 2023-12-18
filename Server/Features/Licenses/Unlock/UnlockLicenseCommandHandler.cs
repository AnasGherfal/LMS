using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Unlock;

public sealed record UnlockLicenseCommandHandler : IRequestHandler<UnlockLicenseCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(UnlockLicenseCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Category Unlocked!",
        };
    }
}
