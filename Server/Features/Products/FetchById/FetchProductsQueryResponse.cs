namespace Server.Features.Products.FetchById;

public sealed record FetchProductByIdQueryResponse
{
    public Guid Id { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string? Provider { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
