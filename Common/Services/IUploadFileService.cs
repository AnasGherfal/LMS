using Common.Services.Dtos;

namespace Common.Services;

public interface IUploadFileService
{
    Task<IList<FileStorageUploadResponse>?> UploadFiles(IList<FileStorageUploadRequest> files);
} 