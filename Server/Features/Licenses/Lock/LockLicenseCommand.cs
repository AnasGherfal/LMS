using Common.Wrappers;

namespace Server.Features.Licenses.Lock;

public sealed record LockLicenseCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
