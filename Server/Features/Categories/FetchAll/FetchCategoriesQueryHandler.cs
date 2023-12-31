using Common.Constants;
using Common.Helpers;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Categories.FetchAll;

public sealed record FetchCategoriesQueryHandler : IRequestHandler<FetchCategoriesQuery, PagedResponse<FetchCategoriesQueryResponse>>
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly AppDbContext _dbContext;
    public FetchCategoriesQueryHandler(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContext = httpContextAccessor;
    }
    
    public async Task<PagedResponse<FetchCategoriesQueryResponse>> Handle(FetchCategoriesQuery request, CancellationToken cancellationToken)
    {
        var pageNumber = request.PageNumber ?? 1;
        
        var pageSize = request.PageSize ?? 5;
        var query = _dbContext.Categories
            .Where(p => string.IsNullOrWhiteSpace(request.Search)
                        || p.Name.Contains(request.Search, StringComparison.CurrentCultureIgnoreCase));
        var data = await query
            .OrderBy(p => p.CreatedOn)
            .Skip((pageNumber - 1) * pageSize)
            .Include(p=>p.Products)
            .Take(pageSize)
            .AsNoTracking()
            .Select(p => new FetchCategoriesQueryResponse()
            {
                Id = p.Id,
                Photo = _httpContext.BlobUrl() + p.Photo,
                Name = p.Name,
                IsActive = p.Status == EntityStatus.Active,
                NumberOfProducts = p.Products.Count(),
                CreatedOn = p.CreatedOn,
            })
            .ToListAsync(cancellationToken: cancellationToken);
        var count = await query.CountAsync(cancellationToken: cancellationToken);
        var totalPages = (int) Math.Ceiling(count / (double) pageSize);
        return new PagedResponse<FetchCategoriesQueryResponse>("", data, totalPages);
    }
}
