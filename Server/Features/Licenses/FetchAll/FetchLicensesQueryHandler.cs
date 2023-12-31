using Common.Constants;
using Common.Entities.HrEntities;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Features.LookUps.FetchDepartments;

namespace Server.Features.Licenses.FetchAll;

public sealed record FetchLicensesQueryHandler(AppDbContext _dbContext) : IRequestHandler<FetchLicensesQuery, PagedResponse<FetchLicensesQueryResponse>>
{
    private readonly AppDbContext _dbContext= _dbContext;
    public async Task<PagedResponse<FetchLicensesQueryResponse>> Handle(FetchLicensesQuery request, CancellationToken cancellationToken)
    {
        var pageNumber = request.PageNumber ?? 1;
        var pageSize = request.PageSize ?? 5;
        var query = _dbContext.Licenses
            .Where(p =>
                string.IsNullOrWhiteSpace(request.DepartmentId)
                || p.DepartmentId == short.Parse(request.DepartmentId!));
        var data = await query
            .OrderBy(p => p.CreatedOn)
            .Include(p => p.Product)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .Select(p=> new FetchLicensesQueryResponse
            {
                Id = p.Id,
                DepartmentId = p.DepartmentId,
                IsActive = p.Status == EntityStatus.Active,
                ExpireDate = p.ExpireDate,
                StartDate = p.StartDate,
                ImpactLevel = p.ImpactLevel,
                ProductName = p.Product.Name,
                CreatedOn = p.CreatedOn,
            })
            .ToListAsync(cancellationToken: cancellationToken);
        var count = await query.CountAsync(cancellationToken: cancellationToken);
        var totalPages = (int)Math.Ceiling(count / (double)pageSize);
        return new PagedResponse<FetchLicensesQueryResponse>("", data, totalPages);
    }
}
