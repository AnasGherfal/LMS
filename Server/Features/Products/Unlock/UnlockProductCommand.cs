using Common.Wrappers;
using MediatR;

namespace Server.Features.Products.Unlock;

public sealed record UnlockProductCommand :IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
