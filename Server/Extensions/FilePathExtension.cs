using Common.Options;
using Common.Services;
using Infrastructure.FileStorage;

namespace Server.Extensions;

public static class FilePathExtension
{
    public static void AddFilePath(this IServiceCollection services, IConfigurationSection section)
    {
        services.Configure<UploadOption>(section);
        services.AddScoped<IUploadFileService, UploadFileService>();
    }
}