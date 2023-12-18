using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Update;

public sealed record UpdateLicenseCommand : IRequest<MessageResponse>
{
    public string? Id { get; private set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IFormFile? Icon { get; set; }

    public void SetId(string id)
    {
        Id = id;
    }

}
