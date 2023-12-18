namespace Common.Entities.Abstracts;

public class FileStorageData
{
    public Guid FileIdentifier { get; set; } = Guid.Empty;
    public string FilePath { get; set; } = string.Empty;
}