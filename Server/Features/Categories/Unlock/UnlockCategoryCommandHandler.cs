using Common.Wrappers;

namespace Server.Features.Categories.Unlock;

public sealed record UnlockCategoryCommandHandler : IRequestHandler<UnlockCategoryCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(UnlockCategoryCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Category Unlocked!",
        };
    }
}
