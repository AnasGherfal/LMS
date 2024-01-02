using Azure.Core;
using Common.Wrappers;
using MediatR;

namespace Server.Features.LookUps.FetchDepartments;

public sealed record FetchDepartmentsQuery : IRequest<ListResponse<FetchDepartmentsQueryResponse>>
{
   
}