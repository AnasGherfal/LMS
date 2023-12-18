using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Delete;

public sealed record DeleteLicenseCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
