using Common;
using Common.Constants;
using Common.Exceptions;
using Common.Helpers;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Infrastructure;
using Management.Protos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Linq;


namespace Server.Features.LookUps;

[ApiController]
[Route("v1.0/[controller]")]

public class LookupsController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    [HttpGet("get-impactLevels")]
    public async Task<IActionResult> GetImpactLevels()
    {
        var impactLevels = Enum.GetValues(typeof(ImpactLevel))
            .Cast <ImpactLevel>()
            .ToList()
            .Select(p=> new FetchLookUpsQueryResponse()
            {
                Id = (short) p,
                Name = p.ToString()
            }).ToList();

        return Ok(impactLevels);
    }
    [HttpGet("get-timeTypes")]
    public async Task<IActionResult> GetTimeTypes()
    {
        var timeTypes = Enum.GetValues(typeof(TimeType))
            .Cast<TimeType>()
            .ToList()
            .Select(p => new FetchLookUpsQueryResponse()
            {
                Id = (short)p,
                Name = p.ToString()
            }).ToList();

        return Ok(timeTypes);
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