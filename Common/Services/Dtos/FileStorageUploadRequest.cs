using Microsoft.AspNetCore.Http;

namespace Common.Services.Dtos;

public record FileStorageUploadRequest(Guid Id, IFormFile File);