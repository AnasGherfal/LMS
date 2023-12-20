namespace Server.Features.Products.FetchById;

public sealed record FetchProductByIdQueryResponse 
{
    public Guid Id { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public int NumberOfLicenses { get; set; }
    public Guid CategoryId { get; set; } = Guid.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
