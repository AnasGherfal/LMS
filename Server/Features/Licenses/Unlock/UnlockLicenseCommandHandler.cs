using Common.Constants;
using Common.Events.License;
using Common.Exceptions;
using Common.Services;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Licenses.Unlock;

public sealed record UnlockLicenseCommandHandler(IClientService _client, AppDbContext _dbContext) : IRequestHandler<UnlockLicenseCommand, MessageResponse>
{
    private readonly IClientService _client = _client;
    private readonly AppDbContext _dbContext = _dbContext;
    public async Task<MessageResponse> Handle(UnlockLicenseCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Licenses.SingleOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.LicenseNotFound));
        if (data.Status == EntityStatus.Active) throw new BadRequestException(nameof(Locale.AlreadyActive));
        if (data.Status != EntityStatus.Locked) throw new BadRequestException(nameof(Locale.CannotBeUnlocked));
        var @event = new LicenseUnlockedEvent(_client.IdentityId, data.Id, data.Sequence + 1, new LicenseUnlockedEventData());
        data.Apply(@event);
        _dbContext.Entry(data).State = EntityState.Modified;
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.LicenseUnlocked),
        };
    }
}
