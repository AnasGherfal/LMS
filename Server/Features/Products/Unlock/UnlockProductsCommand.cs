using Common.Wrappers;

namespace Server.Features.Products.Unlock;

public sealed record UnlockProductCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; } = string.Empty;
}
