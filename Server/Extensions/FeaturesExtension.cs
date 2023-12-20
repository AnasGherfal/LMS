using System.Reflection;
using System.Text;
using Common.Behaviors;
using Common.Options;
using Common.Services;
using FluentValidation;
using Infrastructure;
using Infrastructure.ClientInfo;
using Infrastructure.Models;
using Infrastructure.Services.Department;
using Jose;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Server.Extensions;

public static class FeaturesExtension
{
    public static void AddFeatures(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
  
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
     services.AddAutoMapper(Assembly.GetExecutingAssembly()); 

    }

    public static IServiceCollection AddCustomAuthentication(this IServiceCollection serviceCollection, ConfigurationManager configuration)
    {
        serviceCollection.AddScoped<IClientService, ClientService>();


         serviceCollection.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));

        serviceCollection.AddHttpContextAccessor();
        IConfigurationSection jwtConfig = configuration.GetSection(AuthenticationOption.Section);
        AuthenticationOption? jwtSettings = jwtConfig.Get<AuthenticationOption>();

        serviceCollection.AddAuthorizationBuilder()
            .AddPolicy("RegisteredApp", policy => policy.RequireAssertion(ctx => ctx.User.HasClaim(c => c.Type == "apps" && c.Value.Contains("10"))));

        serviceCollection.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = jwtSettings!.ValidIssuer,
                ValidAudience = jwtSettings.ValidAudience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1)
            };
        });

        serviceCollection.Configure<JwtSettings>(jwtConfig);

        return serviceCollection;
    }
    public static IServiceCollection AddCustomControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection.Configure<ApiBehaviorOptions>(o =>
        {
            o.SuppressModelStateInvalidFilter = true;
        }).AddControllers(o =>
        {
           o.Filters.Add(new AuthorizeFilter("RegisteredApp"));
        });

        return serviceCollection;
    }
}