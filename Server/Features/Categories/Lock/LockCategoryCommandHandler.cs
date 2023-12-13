using Common.Wrappers;

namespace Server.Features.Categories.Lock;

public sealed record LockCategoryCommandHandler : IRequestHandler<LockCategoryCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(LockCategoryCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg="Category Locked!",
        };
    }
}
