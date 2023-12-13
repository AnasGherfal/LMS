using Common.Wrappers;

namespace Server.Features.Categories.Unlock;

public sealed record UnlockCategoryCommand :IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
