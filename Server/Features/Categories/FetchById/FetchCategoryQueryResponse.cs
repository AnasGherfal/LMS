namespace Server.Features.Categories.FetchById;

public sealed record FetchCategoryQueryResponse 
{
    public Guid Id { get; set; }
    public string Photo { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
