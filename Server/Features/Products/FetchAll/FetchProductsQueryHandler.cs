using Common.Constants;
using Common.Helpers;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Products.FetchAll;

public sealed record FetchProductsQueryHandler : IRequestHandler<FetchProductsQuery, PagedResponse<FetchProductsQueryResponse>>
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly AppDbContext _dbContext;
    public FetchProductsQueryHandler(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContext = httpContextAccessor;
    }
    
    public async Task<PagedResponse<FetchProductsQueryResponse>> Handle(FetchProductsQuery request, CancellationToken cancellationToken)
    {
        
        var pageNumber = request.PageNumber ?? 1;
        var pageSize = request.PageSize ?? 5;
        var query = _dbContext.Products
            .Where(p => 
                (string.IsNullOrWhiteSpace(request.Search)
                        || p.Name.Contains(request.Search))
            && (string.IsNullOrWhiteSpace(request.CategoryId)
                || p.CategoryId == Guid.Parse(request.CategoryId!)));
        var data = await query
            .OrderBy(p => p.CreatedOn)
            .Include(p => p.Category)
            .Include(p=> p.Licenses)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .Select(p => new FetchProductsQueryResponse()
            {
                Id = p.Id,
                Icon = _httpContext.BlobUrl() + p.Photo,
                Name = p.Name,
                Category = p.Category!.Name,
                IsActive = p.Status == EntityStatus.Active,
                NumberOfLicenses = p.Licenses.Count(),
                CreatedOn = p.CreatedOn,
            })
            .ToListAsync(cancellationToken: cancellationToken);
        var count = await query.CountAsync(cancellationToken: cancellationToken);
        var totalPages = (int) Math.Ceiling(count / (double) pageSize);
        return new PagedResponse<FetchProductsQueryResponse>("", data, totalPages);
    }
}
