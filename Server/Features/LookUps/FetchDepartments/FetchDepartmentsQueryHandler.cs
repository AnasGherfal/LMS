using Common.Entities.HrEntities;
using Common.Wrappers;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Infrastructure;
using Management.Protos.LMS;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Server.Features.LookUps.FetchDepartments;

public class FetchDepartmentsQueryHandler : IRequestHandler<FetchDepartmentsQuery, ListResponse<FetchDepartmentsQueryResponse>>
{

    private readonly IConfiguration _section;

    public FetchDepartmentsQueryHandler(IConfiguration section)
    {
        _section = section;
    }

    public async Task<ListResponse<FetchDepartmentsQueryResponse>> Handle(FetchDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var channel = GrpcChannel.ForAddress(_section.GetRequiredSection("GrpcHrUrl").Value!, new GrpcChannelOptions()
        {
            HttpHandler = new GrpcWebHandler(new HttpClientHandler())
        });
        var client = new LMSEmpInfo.LMSEmpInfoClient(channel);
        var lookup = await client.GetDepartmentsAsync(new Google.Protobuf.WellKnownTypes.Empty(), cancellationToken: cancellationToken);
        var data = lookup.Content.Select(p => new FetchDepartmentsQueryResponse
        {
            Id = p.Id,
            Name = p.Name,
            Domain=p.Email,
            OwnerName = p.OwnerName,
            Email = p.Email+"@ltt.ly",
            PhoneNumber = p.PhoneNumber,
        }).ToList();
        
        return new ListResponse<FetchDepartmentsQueryResponse>("", data);
    }
}

  
