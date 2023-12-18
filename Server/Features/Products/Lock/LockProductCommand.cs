using Common.Wrappers;
using MediatR;

namespace Server.Features.Products.Lock;

public sealed record LockProductCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
