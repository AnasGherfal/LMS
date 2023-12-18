using Common.Constants;
using Common.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ClientInfo;

public class ClientService(IHttpContextAccessor httpContextAccessor) : IClientService
{
    public string IdentityId { get; } = httpContextAccessor.HttpContext?.User?.FindFirst(nameof(ClaimKey.empId))?.Value ?? "";
    public string EmployeeNumber { get; } = httpContextAccessor.HttpContext?.User?.FindFirst(nameof(ClaimKey.empCode))?.Value ?? "";
    public string DisplayName { get; } = httpContextAccessor.HttpContext?.User?.FindFirst(nameof(ClaimKey.fullName))?.Value ?? "";
    public string Username { get; } = httpContextAccessor.HttpContext?.User?.FindFirst(nameof(ClaimKey.userName))?.Value ?? "";
    public string[] Apps { get; } = ParseApps(httpContextAccessor.HttpContext?.User?.FindFirst(nameof(ClaimKey.apps))?.Value ?? "");
    
    private static string[] ParseApps(string apps)
    {
        return string.IsNullOrEmpty(apps) ? Array.Empty<string>() : apps.Split(",");
    }
}