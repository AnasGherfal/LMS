using Common.Wrappers;

namespace Server.Features.Categories.Lock;

public sealed record LockCategoryCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
