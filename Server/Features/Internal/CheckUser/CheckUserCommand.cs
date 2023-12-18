using Common.Constants;
using MediatR;

namespace Server.Features.Internal.CheckUser;

public sealed record CheckUserCommand: IRequest<SystemPermissions>
{
    public string IdentityId { get; set; } = string.Empty;
    public string EmployeeNumber { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}
