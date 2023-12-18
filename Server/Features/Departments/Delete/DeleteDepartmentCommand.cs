using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.Delete;

public sealed record DeleteDepartmentCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
