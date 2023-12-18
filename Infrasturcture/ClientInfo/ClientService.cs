using Common.Exceptions;
using Common.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ClientInfo;

public class ClientService: IClientService
{
    public string IdentityId { get; }
    public string DisplayName { get; }
    public string Email { get; }
    public bool EmailVerified { get; }
    public long Permission { get; }
    public int UserType { get; }
    
    public ClientService(IHttpContextAccessor httpContextAccessor)
    {
        IdentityId = string.Empty;
        // IdentityId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimsKey.IdentityId.Key())?.Value ?? "";
        // DisplayName = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimsKey.DisplayName.Key())?.Value ?? "User";
        // Email = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimsKey.Email.Key())?.Value ?? "";
        // Permission = long.Parse(httpContextAccessor.HttpContext?.User?.FindFirst(ClaimsKey.Permissions.Key())?.Value ?? "0");
        // UserType = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirst(ClaimsKey.UserType.Key())?.Value ?? "1");
        // EmailVerified = bool.Parse(httpContextAccessor.HttpContext?.User?.FindFirst(ClaimsKey.EmailVerified.Key())?.Value ?? "False");
    }
}