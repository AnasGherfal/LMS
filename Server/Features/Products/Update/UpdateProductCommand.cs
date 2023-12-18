using Common.Wrappers;
using MediatR;

namespace Server.Features.Products.Update;

public sealed record UpdateProductCommand : IRequest<MessageResponse>
{
    public string? Id { get; private set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Provider { get; set; }
    public IFormFile? Photo { get; set; }

    public void SetId(string id)
    {
        Id = id;
    }

}
