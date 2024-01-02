using Common.Constants;
using Common.Exceptions;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Licenses.FetchById;

public sealed record FetchLicenseQueryHandler(AppDbContext _dbContext) : IRequestHandler<FetchLicenseQuery, ContentResponse<FetchLicenseQueryResponse>>
{
    private readonly AppDbContext _dbContext = _dbContext;
    public async Task<ContentResponse<FetchLicenseQueryResponse>> Handle(FetchLicenseQuery request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        
        var data = await _dbContext.Licenses
            .Include(p=> p.Product)
            .Where(p => p.Id == id)
            .Select(p => new FetchLicenseQueryResponse()
            {
                Id = p.Id,
                ProductName = p.Product.Name,
                ProductId = p.ProductId,
                DepartmentId=p.DepartmentId,
                SerialKey = p.SerialKey,
                StartDate=p.StartDate,
                ExpireDate=p.ExpireDate,
                EndOfManufacture = p.EndOfManufacture,
                EndOfSale = p.EndOfSale,
                EndOfSupport = p.EndOfSupport,
                ProductType = p.ProductType,
                ImpactLevel =p.ImpactLevel,
                ImpactDescription=p.ImpactDescription,
                NumOfDevices=p.NumOfDevices,
                TimeType=p.TimeType,
                PriceInLYD=p.PriceInLYD,
                PriceInUSD=p.PriceInUSD,
                IsActive = p.Status == EntityStatus.Active,
                CreatedOn = p.CreatedOn,
            })
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.LicenseNotFound));
        return new ContentResponse<FetchLicenseQueryResponse>("", data);

    }
}
