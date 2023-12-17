namespace Server.Features.Licenses.FetchById;

public sealed record FetchLicenseQueryResponse 
{
    public Guid Id { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
