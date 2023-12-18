using Common.Constants;
using Common.Entities;
using Common.Events.Product;
using Common.Exceptions;
using Common.Services;
using Common.Services.Dtos;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Products.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, MessageResponse>
{
    private readonly IClientService _client;
    private readonly AppDbContext _dbContext;
    private readonly IUploadFileService _uploadFile;

    public UpdateProductCommandHandler(AppDbContext dbContext, IClientService client, IUploadFileService uploadFile)
    {
        _dbContext = dbContext;
        _client = client;
        _uploadFile = uploadFile;
    }
    public async Task<MessageResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id!);
        var data = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (data == null) throw new NotFoundException(nameof(Locale.ProductNotFound));
        if (data.Status != EntityStatus.Active) throw new BadRequestException(nameof(Locale.IsLocked));
        if (data.IsDeleted) throw new BadRequestException(nameof(Locale.AlreadyDeleted));
        var @event = new ProductUpdatedEvent(_client.IdentityId, data.Id, data.Sequence + 1, new ProductUpdatedEventData()
        {
            Name = request.Name,
            Description = request.Description,
            Provider = request.Provider,
            OldFileIdentifier = data.Photo,
            FileIdentifier = null,
        });
        if (request.Photo != null)
        {
            var fileRequests = new List<FileStorageUploadRequest>()
            {
                new(Guid.NewGuid(), request.Photo!),
            };
            var uploadPath = await _uploadFile.UploadFiles(fileRequests);
            if (uploadPath == null) throw new BadRequestException(nameof(Locale.ProductPhotoUploadField));
            @event.Data.FileIdentifier = uploadPath.First().Id;
            await _dbContext.BlobFiles.AddAsync(new BlobFile()
            {
                Id = uploadPath.First().Id,
                FilePath = uploadPath.First().Link,
                FileContent = uploadPath.First().ContentType,
            }, cancellationToken);
        }
        data.Apply(@event);
        _dbContext.Entry(data).State = EntityState.Modified;
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.ProductUpdated),
        };
    }
}
