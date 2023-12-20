using Common.Constants;
using Common.Exceptions;
using Common.Helpers;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Products.FetchById;

public sealed record FetchProductByIdQueryHandler : IRequestHandler<FetchProductByIdQuery, ContentResponse<FetchProductByIdQueryResponse>>
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly AppDbContext _dbContext;

    public FetchProductByIdQueryHandler(AppDbContext dbContext, IHttpContextAccessor httpContext)
    {
        _dbContext = dbContext;
        _httpContext = httpContext;
    }
    
    public async Task<ContentResponse<FetchProductByIdQueryResponse>> Handle(FetchProductByIdQuery request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Products
            .Include(p => p.Category)
            .Include(p=>p.Licenses)
            .Where(p => p.Id == id)
            .Select(p => new FetchProductByIdQueryResponse()
            {
                Id = p.Id,
                Icon = _httpContext.BlobUrl() + p.Photo,
                Name = p.Name,
                Description = p.Description,
                Provider = p.Provider,
                CategoryName = p.Category!.Name,
                CategoryId = p.CategoryId,
                NumberOfLicenses=p.Licenses.Count(),
                IsActive = p.Status == EntityStatus.Active,
                CreatedOn = DateTime.UtcNow,
            })
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.ProductNotFound));
        return new ContentResponse<FetchProductByIdQueryResponse>("", data);
    }
}
