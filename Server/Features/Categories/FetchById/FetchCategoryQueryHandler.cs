using Common.Constants;
using Common.Exceptions;
using Common.Helpers;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Categories.FetchById;

public sealed record FetchCategoryQueryHandler : IRequestHandler<FetchCategoryQuery, ContentResponse<FetchCategoryQueryResponse>>
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly AppDbContext _dbContext;

    public FetchCategoryQueryHandler(AppDbContext dbContext, IHttpContextAccessor httpContext)
    {
        _dbContext = dbContext;
        _httpContext = httpContext;
    }
    
    public async Task<ContentResponse<FetchCategoryQueryResponse>> Handle(FetchCategoryQuery request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Categories
            .Where(p => p.Id == id)
            .Select(p => new FetchCategoryQueryResponse()
            {
                Id = p.Id,
                Icon = _httpContext.BlobUrl() + p.Photo,
                Name = p.Name,
                Description = p.Description,
                IsActive = p.Status == EntityStatus.Active,
                CreatedOn = DateTime.UtcNow,
            })
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.CategoryNotFound));
        return new ContentResponse<FetchCategoryQueryResponse>("", data);
    }
}
