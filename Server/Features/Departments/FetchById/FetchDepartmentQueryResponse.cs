namespace Server.Features.Departments.FetchById;

public sealed record FetchDepartmentQueryResponse 
{
    public Guid Id { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
