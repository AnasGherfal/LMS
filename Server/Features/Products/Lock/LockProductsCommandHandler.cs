using Common.Wrappers;

namespace Server.Features.Products.Lock;

public sealed record LockCategoryCommandHandler : IRequestHandler<LockProductCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(LockProductCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg="Category Locked!",
        };
    }
}
