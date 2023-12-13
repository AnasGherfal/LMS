namespace Infrastructure.Models;

public class Product: BaseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Provider { get; set; } = default!;
    public Guid CategoryId { get; set; }

}
