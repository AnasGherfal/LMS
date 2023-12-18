using Common.Wrappers;
using MediatR;

namespace Server.Features.Categories.Unlock;

public sealed record UnlockCategoryCommand :IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
