using Common.Constants;

namespace Infrastructure.Models.Mappers;

public class DocumentForCategory
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid CategoryId { get; set; } = Guid.Empty;
    public IconType IconType { get; set; } = IconType.CategoryIcon;
    public string FileLink { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
}