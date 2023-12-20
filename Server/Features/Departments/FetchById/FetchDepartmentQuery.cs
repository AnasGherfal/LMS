﻿using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.FetchById;

public sealed record FetchDepartmentQuery : IRequest<ContentResponse<FetchDepartmentQueryResponse>>
{
    public string? Id { get; set; }
}