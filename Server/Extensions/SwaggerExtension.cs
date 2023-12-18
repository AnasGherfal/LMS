using Microsoft.OpenApi.Models;

namespace Server.Extensions;

public static class SwaggerExtension
{
    public const string ConsumerV1 = "consumer-v1";
    public const string ManagementV1 = "management-v1";

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    public static void UseSwagger(this IApplicationBuilder app, bool isDevelopment)
    {
        if (!isDevelopment) return;
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}