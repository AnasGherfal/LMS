using AutoMapper;
using Bogus;
using Common.Constants;
using Common.Helpers;
using Common.Wrappers;
using Infrastructure;
using Infrastructure.Services.Department;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Features.Departments.FetchAll;
using System.Collections.Generic;

namespace Server.Features.Departments.GetDepartments;

public class GetDepartmentsQueryHandler: IRequestHandler<GetDepartmentsQuery, List<GetDepartmentsQueryResponse>>
{
 

     private readonly IMapper _mapper  ;
    private readonly IDepartmentService _service;

    public GetDepartmentsQueryHandler(IDepartmentService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<List<GetDepartmentsQueryResponse>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {

        //var pageNumber = request.PageNumber ?? 1;
        //var pageSize = request.PageSize ?? 5;
        var query = await _service.GetAllDeparmentAsync();

 
               //    .Where(p => string.IsNullOrWhiteSpace(request.Search)
               //                || p.EntityName.Contains(request.Search));
               //var data = await query
               //    .OrderBy(p => p.EntityId)
               //    .Skip((pageNumber - 1) * pageSize)
               //    .Take(pageSize)
               //    .AsNoTracking()
               //    .Select(p => new GetDepartmentsQueryResponse()
               //    {
               //        Id = p.EntityId,
               //         Name = p.EntityName,

        //    })
        //    .ToListAsync(cancellationToken: cancellationToken);
        //var count = await query.CountAsync(cancellationToken: cancellationToken);
        //var totalPages = (int) Math.Ceiling(count / (double) pageSize);
               var result = _mapper.Map<List<GetDepartmentsQueryResponse>>(query);

        return result;



    } }

  
