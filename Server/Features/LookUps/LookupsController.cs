using Common;
using Common.Constants;
using Common.Exceptions;
using Common.Helpers;
using Common.Wrappers;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Management.Protos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Abstract;
using Server.Features.LookUps.FetchDepartments;


namespace Server.Features.LookUps;

[ApiController]
[Route("v1.0/[controller]")]

public class LookupsController : ManagementController
{
    [HttpGet("Departments")]
    public async Task<ListResponse<FetchDepartmentsQueryResponse>> FetchDepartments()
        => await Mediator.Send(new FetchDepartmentsQuery());
    
    
    [HttpGet("Impact-Levels")]
    public async Task<ListResponse<FetchLookUpsQueryResponse>> GetImpactLevels()
    {
        var data = Enum.GetValues(typeof(ImpactLevel))
            .Cast <ImpactLevel>()
            .ToList()
            .Select(p=> new FetchLookUpsQueryResponse()
            {
                Id = (short) p,
                Name = p.ToString()
            }).ToList();
        return new ListResponse<FetchLookUpsQueryResponse>("", data);
    }
    
    [HttpGet("License-Types")]
    public async Task<ListResponse<FetchLookUpsQueryResponse>> GetTimeTypes()
    {
        var data = Enum.GetValues(typeof(TimeType))
            .Cast<TimeType>()
            .ToList()
            .Select(p => new FetchLookUpsQueryResponse()
            {
                Id = (short)p,
                Name = p.ToString()
            }).ToList();
        return new ListResponse<FetchLookUpsQueryResponse>("", data);
    }
}