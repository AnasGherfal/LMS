using Common.Constants;
using Common.Events.Product;
using Common.Exceptions;
using Common.Services;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Products.Lock;

public sealed record LockProductCommandHandler : IRequestHandler<LockProductCommand, MessageResponse>
{
    private readonly IClientService _client;
    private readonly AppDbContext _dbContext;

    public LockProductCommandHandler(AppDbContext dbContext, IClientService client)
    {
        _dbContext = dbContext;
        _client = client;
    }
    public async Task<MessageResponse> Handle(LockProductCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.ProductNotFound));
        if (data.Status == EntityStatus.Locked) throw new BadRequestException(nameof(Locale.AlreadyLocked));
        if (data.Status != EntityStatus.Active) throw new BadRequestException(nameof(Locale.CannotBeLocked));
        var @event = new ProductLockedEvent(_client.IdentityId, data.Id, data.Sequence + 1, new ProductLockedEventData());
        data.Apply(@event);
        _dbContext.Entry(data).State = EntityState.Modified;
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.ProductLocked),
        };
    }
}
