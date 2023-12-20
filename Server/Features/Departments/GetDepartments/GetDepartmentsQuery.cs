using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.GetDepartments;

public sealed record GetDepartmentsQuery : IRequest<List<GetDepartmentsQueryResponse>>
{
 
}