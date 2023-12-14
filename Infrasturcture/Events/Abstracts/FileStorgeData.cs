using Common.Constants;

namespace Infrastructure.Events.Abstracts;
public class FileStorageData
{
    public Guid FileIdentifier { get; set; } = Guid.Empty;
    public IconType IconType { get; set; } = default;
    public string FileLink { get; set; } = string.Empty;
}
