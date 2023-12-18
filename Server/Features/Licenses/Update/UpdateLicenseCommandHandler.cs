using Common.Constants;
using Common.Entities;
using Common.Events.License;
using Common.Events.Product;
using Common.Exceptions;
using Common.Services;
using Common.Services.Dtos;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Licenses.Update;

public class UpdateLicenseCommandHandler(AppDbContext _dbContext, IClientService _client) : IRequestHandler<UpdateLicenseCommand, MessageResponse>
{
    private readonly IClientService _client=_client;
    private readonly AppDbContext _dbContext=_dbContext;

    public async Task<MessageResponse> Handle(UpdateLicenseCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Licenses.SingleOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.LicenseNotFound));
        if (data.Status != EntityStatus.Active) throw new BadRequestException(nameof(Locale.IsLocked));
        if (data.IsDeleted) throw new BadRequestException(nameof(Locale.AlreadyDeleted));
        var @event = new LicenseUpdatedEvent(_client.IdentityId, data.Id, data.Sequence + 1, new LicenseUpdatedEventData()
        {
            Contact = request.Contact,
            ImpactLevel= request.ImpactLevel,
            ImpactDescription= request.ImpactDescription,
            StartDate = request.StartDate,
            ExpireDate = request.ExpireDate,
            PriceInUSD= request.PriceInUSD,
            PriceInLYD= request.PriceInLYD,
            NumOfDevices= request.NumOfDevices,
            SerialKey= request.SerialKey,
            TimeType= request.TimeType,
        });
        data.Apply(@event);
        _dbContext.Entry(data).State = EntityState.Modified;
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.LicenseUpdated),
        };
    }
}
