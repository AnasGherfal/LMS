using Common.Options;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Extensions;

public static class PersistenceExtension
{
    public static void AddPersistence(this IServiceCollection services, IConfigurationSection section)
    {
        var connectionString = section.GetValue<string>(nameof(PersistenceOption.ConnectionString));
        services.AddDbContext<AppDbContext>(o =>
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                o.UseInMemoryDatabase("IN_MEMORY_TEST");
                o.EnableDetailedErrors();
            }
            else
            {
                o.UseSqlServer(connectionString);
            }
        });

        var connectionString2 = section.GetValue<string>(nameof(PersistenceOption.ConnectionString2));
        services.AddDbContext<HRMSContext>(o =>
        {
            if (string.IsNullOrWhiteSpace(connectionString2))
            {
                o.UseInMemoryDatabase("IN_MEMORY_TEST");
                o.EnableDetailedErrors();
            }
            else
            {
                o.UseSqlServer(connectionString2);
            }
        });
 
    }
    
    
    
    public static async void UsePersistence(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await using var dbConte = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (dbConte.Database.IsSqlServer())
        {
            await dbConte.Database.MigrateAsync();
        }
    }
}