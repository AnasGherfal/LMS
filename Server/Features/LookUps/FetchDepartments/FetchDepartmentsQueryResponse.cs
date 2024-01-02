using Common.Wrappers;
using MediatR;
using System;

namespace Server.Features.LookUps.FetchDepartments;

public sealed record FetchDepartmentsQueryResponse : IRequest<PagedResponse<FetchDepartmentsQueryResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
   public string OwnerName { get; set; }=string.Empty;
    public string Email {  get; set; } = string.Empty;
    public string PhoneNumber { get; set; } =string.Empty;
    public string Domain { get; set; } = string.Empty;
}
