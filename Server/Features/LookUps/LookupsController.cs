using Common;
using Common.Exceptions;
using Common.Helpers;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Infrastructure;
using Management.Protos;
using Microsoft.AspNetCore.Mvc;


namespace Server.Features.LookUps;

[ApiController]
[Route("v1.0/[controller]")]

public class LookupsController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    [HttpGet("get-entities")]
    public async Task<IActionResult> GetEntities()
    {

        return Ok();
    }

    [HttpGet("get-app-users-list")]
    public async Task<IActionResult> GetUsersList()
    {
        if (_httpContextAccessor.GetRoleId() != Roles.Admin) throw new UnauthorizedException("ليس لديك الصلاحيات اللازمة");

        // grpc user list
        var address = _configuration.GetSection("GrpcUserUrl").Value;
        var channel = GrpcChannel.ForAddress(address!, new GrpcChannelOptions
        {
            HttpHandler = new GrpcWebHandler(new HttpClientHandler())
        });
        var client = new Management.Protos.Users.UsersClient(channel);
        var request = new AppUsersListRequest()
        {
            AppId = 10
        };

        var users = await client.GetAppUsersListAsync(request);

        return Ok(users.UsersList);
    }
}