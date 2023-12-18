using Microsoft.AspNetCore.Http;

namespace Common.Helpers;

public static class HttpContextExtensions
{

    public static int GetUserId(this IHttpContextAccessor context)
    {
        int userId = context.HttpContext!.User.Claims
                                    .Where(c => c.Type == "userId")
                                    .Select(c => int.Parse(c.Value))
                                    .Single();
        return userId;
    }

    public static int GetEmpId(this IHttpContextAccessor context)
    {
        int empId = context.HttpContext!.User.Claims
                                    .Where(c => c.Type == "empId")
                                    .Select(c => int.Parse(c.Value))
                                    .Single();
        return empId;
    }
    public static int GetEntityId(this IHttpContextAccessor context)
    {
        var entityId = Int32.Parse(context.HttpContext!.Request.Cookies.First(s => s.Key == "entityId").Value.ToString());

        return entityId;
    }  
    public static int GetActEntityId(this IHttpContextAccessor context)
    {
        var actEntityId = Int32.Parse(context.HttpContext!.Request.Cookies.First(s => s.Key == "actEntityId").Value.ToString());
        return actEntityId;
    }
    public static int GetRoleId(this IHttpContextAccessor context)
    {
        
        var roleId = Int32.Parse(context.HttpContext!.Request.Cookies.First(s => s.Key == "roleId").Value.ToString());
        // Log.Fatal(roleId.ToString());
        return roleId;
    }
    
    
    
    public static string ApiUrl(this IHttpContextAccessor context, string source, string destination)
    {
        var url = $"{context?.HttpContext?.Request.Scheme}://{context?.HttpContext?.Request.Host.ToUriComponent()}{context?.HttpContext?.Request.PathBase}{context?.HttpContext?.Request.Path}".Replace(source, destination);
        return url;
    }
    
}