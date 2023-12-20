using System.Reflection;
using Common.Behaviors;
using FluentValidation;
using MediatR;

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