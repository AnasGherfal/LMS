﻿using Common.Wrappers;
using MediatR;

namespace Server.Features.Departments.FetchAll;

public sealed record FetchDepartmentsQuery : IRequest<PagedResponse<FetchDepartmentsQueryResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}