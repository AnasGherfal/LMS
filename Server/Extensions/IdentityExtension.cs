using System.Text;
using Common.Exceptions;
using Common.Options;
using Common.Services;
using Infrastructure.ClientInfo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Server.Extensions;

public static class IdentityExtension
{
    public static void AddIdentity(this IServiceCollection services, IConfigurationSection section)
    {
        services.Configure<AuthenticationOption>(section);
        services.AddScoped<IClientService, ClientService>();
        services.AddHttpContextAccessor();
        var authOption = section.Get<AuthenticationOption>()!;
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOption.Secret)),
                    ValidAudience = authOption.Audience,
                    ValidIssuer = authOption.Issuer,
                    ClockSkew = TimeSpan.Zero,
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context => throw new NotAuthenticatedException("FAILED"),
                    OnForbidden = context => throw new ForbiddenException("FORBIDDEN"),
                };
            });
        services.AddAuthorization();
    }
}