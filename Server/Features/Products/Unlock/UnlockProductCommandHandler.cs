using Common.Constants;
using Common.Events.Product;
using Common.Exceptions;
using Common.Services;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Products.Unlock;

public sealed record UnlockProductCommandHandler : IRequestHandler<UnlockProductCommand, MessageResponse>
{
    private readonly IClientService _client;
    private readonly AppDbContext _dbContext;

    public UnlockProductCommandHandler(AppDbContext dbContext, IClientService client)
    {
        _dbContext = dbContext;
        _client = client;
    }
    public async Task<MessageResponse> Handle(UnlockProductCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.ProductNotFound));
        if (data.Status == EntityStatus.Active) throw new BadRequestException(nameof(Locale.AlreadyActive));
        if (data.Status != EntityStatus.Locked) throw new BadRequestException(nameof(Locale.CannotBeUnlocked));
        var @event = new ProductUnlockedEvent(_client.IdentityId, data.Id, data.Sequence + 1, new ProductUnlockedEventData());
        data.Apply(@event);
        _dbContext.Entry(data).State = EntityState.Modified;
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.ProductUnlocked),
        };
    }
}
