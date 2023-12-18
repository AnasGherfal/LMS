using Common.Constants;
using Common.Events.License;
using Common.Events.Product;
using Common.Exceptions;
using Common.Services;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Licenses.Lock;

public sealed record LockLicenseCommandHandler(AppDbContext _dbContext, IClientService _client) : IRequestHandler<LockLicenseCommand, MessageResponse>
{
    private readonly IClientService _client = _client;
    private readonly AppDbContext _dbContext = _dbContext;
    public async Task<MessageResponse> Handle(LockLicenseCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Licenses.SingleOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.LicenseNotFound));
        if (data.Status == EntityStatus.Locked) throw new BadRequestException(nameof(Locale.AlreadyLocked));
        if (data.Status != EntityStatus.Active) throw new BadRequestException(nameof(Locale.CannotBeLocked));
        var @event = new LicenseLockedEvent(_client.IdentityId, data.Id, data.Sequence + 1, new LicenseLockedEventData());
        data.Apply(@event);
        _dbContext.Entry(data).State = EntityState.Modified;
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.LicenseLocked),
        };
    }
}
