using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Lock;

public sealed record LockLicenseCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
