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
}