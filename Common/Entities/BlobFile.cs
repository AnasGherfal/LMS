using Common.Constants;

namespace Common.Entities;

public class BlobFile
{
    public Guid Id { get; set; } = Guid.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string FileContent { get; set; } = string.Empty;
    public EntityStatus Status { get; set; }
}