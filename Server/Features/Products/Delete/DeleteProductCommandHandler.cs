using Common.Constants;
using Common.Events.Product;
using Common.Exceptions;
using Common.Services;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Products.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, MessageResponse>
{
    private readonly IClientService _client;
    private readonly AppDbContext _dbContext;

    public DeleteProductCommandHandler(AppDbContext dbContext, IClientService client)
    {
        _dbContext = dbContext;
        _client = client;
    }
    public async Task<MessageResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.ProductNotFound));
        if (_dbContext.Licenses.Any(p => p.ProductId == id))
            throw new BadRequestException(nameof(Locale.ProductHaveLicense));
        if (data.Status == EntityStatus.Locked) throw new BadRequestException(nameof(Locale.IsLocked));
        if (data.IsDeleted) throw new BadRequestException(nameof(Locale.AlreadyDeleted));
        var @event = new ProductDeletedEvent(_client.IdentityId, data.Id, data.Sequence + 1, new ProductDeletedEventData());
        data.Apply(@event);
        _dbContext.Entry(data).State = EntityState.Modified;
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.ProductDeleted),
        };
    }
}
