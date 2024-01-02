using Common.Constants;
using Common.Entities;
using Common.Events.License;
using Common.Exceptions;
using Common.Services;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Licenses.Create;

public sealed record CreateLicenseCommandHandler(IClientService _client, AppDbContext _dbContext) : IRequestHandler<CreateLicenseCommand, MessageResponse>
{
    private readonly IClientService _client = _client;
    private readonly AppDbContext _dbContext =_dbContext;
    public async Task<MessageResponse> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
    {
		var productId= Guid.Parse(request.ProductId);
        if (productId != null) {
            if (await _dbContext.Products.Where(p => p.Id == productId).AnyAsync(p => p.Status == EntityStatus.Locked, cancellationToken: cancellationToken))
                throw new BadRequestException(nameof(Locale.ProductLocked));
           
        }
        var @event = new LicenseCreatedEvent(_client.IdentityId, Guid.NewGuid(), new LicenseCreatedEventData()
        {
            DepartmentId =short.Parse(request.DepartmentId!),
            ProductId = Guid.Parse(request.ProductId!),
            SerialKey = request.SerialKey!,
            EndOfSupport=request.EndOfSupport!,
            EndOfSale=request.EndOfSale,
            EndOfManufacture=request.EndOfManufacture,
            ProductType=request.ProductType!.Value,
            ImpactLevel = request.ImpactLevel!.Value,
            ImpactDescription = request.ImpactDescription!,
           StartDate = DateTime.Parse(request.StartDate!),
            ExpireDate = DateTime.Parse(request.ExpireDate!),
            PriceInUSD = request.PriceInUSD!.Value,
            PriceInLYD = request.PriceInLYD!.Value,
            NumOfDevices=request.NumOfDevices!,
            TimeType = request.TimeType!.Value,
        });
        var data = new License();
        data.Apply(@event);
        await _dbContext.Licenses.AddAsync(data, cancellationToken);
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.LicenseCreated)
        };

    }
}
