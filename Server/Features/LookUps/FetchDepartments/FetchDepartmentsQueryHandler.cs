using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.LookUps.FetchDepartments;

public class FetchDepartmentsQueryHandler : IRequestHandler<FetchDepartmentsQuery, ListResponse<FetchDepartmentsQueryResponse>>
{
    private readonly HrDbContext _hrDbContext;

    public FetchDepartmentsQueryHandler(HrDbContext hrDbContext)
    {
        _hrDbContext = hrDbContext;
    }

    public async Task<ListResponse<FetchDepartmentsQueryResponse>> Handle(FetchDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var data = await _hrDbContext.AdminEntities
            .Select(p => new FetchDepartmentsQueryResponse()
            {
                Id = p.EntityId,
                Name = p.EntityName,
            })
            .ToListAsync(cancellationToken: cancellationToken);
        return new ListResponse<FetchDepartmentsQueryResponse>("", data);
    }
}

  
