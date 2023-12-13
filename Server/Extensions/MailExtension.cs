using Server.Options;

namespace Server.Extensions;

public static class MailExtension
{
    public static void AddMail(this IServiceCollection services, IConfigurationSection section)
    {
        services.Configure<MailOption>(section);
    }
}