using Common.Wrappers;

namespace Server.Features.Products.Create;

public sealed record CreateProductCommand: IRequest<MessageResponse>
{
    public string? CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Provider { get; set; }
    public IFormFile? Icon { get; set; }
}

