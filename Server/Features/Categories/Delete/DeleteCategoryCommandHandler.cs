using Common.Constants;
using Common.Events.Category;
using Common.Exceptions;
using Common.Services;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Categories.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, MessageResponse>
{
    private readonly IClientService _client;
    private readonly AppDbContext _dbContext;

    public DeleteCategoryCommandHandler(AppDbContext dbContext, IClientService client)
    {
        _dbContext = dbContext;
        _client = client;
    }
    public async Task<MessageResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Categories.SingleOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.CategoryNotFound));
        if (await _dbContext.Products.AnyAsync(p => p.CategoryId == id, cancellationToken: cancellationToken))
            throw new BadRequestException(nameof(Locale.CategoryHaveProduct));
        if (data.Status == EntityStatus.Locked) throw new BadRequestException(nameof(Locale.IsLocked));
        if (data.IsDeleted) throw new BadRequestException(nameof(Locale.AlreadyDeleted));
        var @event = new CategoryDeletedEvent(_client.IdentityId, data.Id, data.Sequence + 1, new CategoryDeletedEventData());
        data.Apply(@event);
        _dbContext.Entry(data).State = EntityState.Modified;
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.CategoryDeleted),
        };
    }
}
