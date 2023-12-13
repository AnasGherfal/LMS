using Server.Options;

namespace Server.Extensions;

public static class FilePathExtension
{
    public static void AddFilePath(this IServiceCollection services, IConfigurationSection section)
    {
        services.Configure<FilePaths>(section);
    }
}