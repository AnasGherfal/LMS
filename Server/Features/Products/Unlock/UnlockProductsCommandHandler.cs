using Common.Wrappers;

namespace Server.Features.Products.Unlock;

public sealed record UnlockProductCommandHandler : IRequestHandler<UnlockProductCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(UnlockProductCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Category Unlocked!",
        };
    }
}
