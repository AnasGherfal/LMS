using Common.Constants;
using Common.Events.Category;
using Common.Exceptions;
using Common.Services;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Categories.Unlock;

public sealed record UnlockCategoryCommandHandler : IRequestHandler<UnlockCategoryCommand, MessageResponse>
{
    private readonly IClientService _client;
    private readonly AppDbContext _dbContext;

    public UnlockCategoryCommandHandler(AppDbContext dbContext, IClientService client)
    {
        _dbContext = dbContext;
        _client = client;
    }
    public async Task<MessageResponse> Handle(UnlockCategoryCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Categories.SingleOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.CategoryNotFound));
        if (data.Status == EntityStatus.Active) throw new BadRequestException(nameof(Locale.AlreadyActive));
        if (data.Status != EntityStatus.Locked) throw new BadRequestException(nameof(Locale.CannotBeUnlocked));
        var @event = new CategoryUnlockedEvent(_client.IdentityId, data.Id, data.Sequence + 1, new CategoryUnlockedEventData());
        data.Apply(@event);
        _dbContext.Entry(data).State = EntityState.Modified;
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.CategoryUnlocked),
        };
    }
}
