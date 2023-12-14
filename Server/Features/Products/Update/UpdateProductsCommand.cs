using Common.Wrappers;

namespace Server.Features.Products.Update;

public sealed record UpdateProductCommand: IRequest<MessageResponse>
{
    public string? Id { get; private set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Provider { get; set; }
    public IFormFile? Icon { get; set; }
    
    public void SetId(string id)
    {
        Id = id;
    }
}
