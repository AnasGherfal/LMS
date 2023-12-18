using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Create;

public sealed record CreateLicenseCommand: IRequest<MessageResponse>
{
    public string? Name { get; set; }
    public string? Description { get; set; }

}
