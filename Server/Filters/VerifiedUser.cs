using Common.Constants;
using Common.Entities;
using Common.Exceptions;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Server.Features.Internal.CheckUser;

namespace Server.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class VerifiedUser : Attribute, IAuthorizationFilter
{
    private readonly SystemPermissions _requiredPermission;
    
    public VerifiedUser(SystemPermissions permission = SystemPermissions.None)
    {
        _requiredPermission = permission;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!HasIdentifier(context)) throw new NotAuthenticatedException("Not Authenticated");
        if (!HasAppPermission(context)) throw new NotAuthenticatedException("NOT_HAVE_APP_PERMISSION");
        if (!HasPermission(context)) throw new ForbiddenException("Permission_Denied");
    }
    
    private static bool HasIdentifier(AuthorizationFilterContext context)
    {
        var identifier = context.HttpContext.User.FindFirst(nameof(ClaimKey.empId))?.Value ?? "";
        return !string.IsNullOrWhiteSpace(identifier);
    }
    
    private static bool HasAppPermission(AuthorizationFilterContext context)
    {
        var apps = ParseApps(context.HttpContext.User.FindFirst(nameof(ClaimKey.apps))?.Value ?? "");
        return apps.Contains("4");
    }
    
    private bool HasPermission(AuthorizationFilterContext context)
    {
        var mediator = context.HttpContext
            .RequestServices
            .GetService<IMediator>()!;
        var userPermissions = mediator.Send(new CheckUserCommand()
        {
            IdentityId = context.HttpContext.User?.FindFirst(nameof(ClaimKey.empId))?.Value!,
            EmployeeNumber = context.HttpContext.User?.FindFirst(nameof(ClaimKey.empCode))?.Value!,
            DisplayName = context.HttpContext.User?.FindFirst(nameof(ClaimKey.fullName))?.Value!,
            Username = context.HttpContext.User?.FindFirst(nameof(ClaimKey.userName))?.Value!,
        }).Result;
        return userPermissions.HasFlag(_requiredPermission);
    }
    
    private static string[] ParseApps(string apps)
    {
        return string.IsNullOrEmpty(apps) ? Array.Empty<string>() : apps.Split(",");
    }
}