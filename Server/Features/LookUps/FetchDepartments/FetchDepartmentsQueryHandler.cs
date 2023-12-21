using Common.Entities.HrEntities;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Cryptography;

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
        var res = await (from a in _hrDbContext.ManagementPostions
                  join b in _hrDbContext.Employees
                       on a.EmpId equals b.EmpId into g
                  from d in g.DefaultIfEmpty()
                  select new
                  {
                      entityid = a.EntityId,
                      entityname = _hrDbContext.AdminEntities.Where(e => e.EntityId == a.EntityId).Select(n => n.EntityName).Single(),
                      name = d.FirstName + " " + d.LastName
                  })
                  .Select(p => new FetchDepartmentsQueryResponse()
            {
                Id = p.entityid,
                Name = p.entityname,
                OwnerName= p.name
             })
            .ToListAsync(cancellationToken: cancellationToken);
        return new ListResponse<FetchDepartmentsQueryResponse>("", res);
    }
}

  
