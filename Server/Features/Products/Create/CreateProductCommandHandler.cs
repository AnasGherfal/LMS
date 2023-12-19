using Common.Constants;
using Common.Entities;
using Common.Events.Category;
using Common.Events.Product;
using Common.Exceptions;
using Common.Services;
using Common.Services.Dtos;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Products.Create;

public sealed record CreateProductCommandHandler : IRequestHandler<CreateProductCommand, MessageResponse>
{
    private readonly IClientService _client;
    private readonly IUploadFileService _uploadFile;
    private readonly AppDbContext _dbContext;

    public CreateProductCommandHandler(AppDbContext dbContext, IUploadFileService uploadFile, IClientService client)
    {
        _dbContext = dbContext;
        _uploadFile = uploadFile;
        _client = client;
    }

    public async Task<MessageResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (request.CategoryId != null)
        {
            if (_dbContext.Categories.Where(p => p.Id == Guid.Parse(request.CategoryId)).Any(p => p.Status == EntityStatus.Locked))
                throw new BadRequestException(nameof(Locale.CategoryLocked));

        }
        var nameExists = await _dbContext.Products.AnyAsync(p => p.Name == request.Name!, cancellationToken: cancellationToken);
        if (nameExists) throw new BadRequestException(nameof(Locale.ProductNameExists));
        var fileRequests = new List<FileStorageUploadRequest>()
        {
            new(Guid.NewGuid(), request.Photo!),
        };
        var uploadPath = await _uploadFile.UploadFiles(fileRequests);
        if (uploadPath == null) throw new BadRequestException(nameof(Locale.ProductPhotoUploadField));
        var @event = new ProductCreatedEvent(_client.IdentityId, Guid.NewGuid(), new ProductCreatedEventData()
        {
            CategoryId = Guid.Parse(request.CategoryId!),
            Name = request.Name!,
            Description = request.Description!,
            Provider = request.Provider!,
            FileIdentifier = uploadPath.First().Id,
        });
        var data = new Product();
        data.Apply(@event);
        await _dbContext.BlobFiles.AddAsync(new BlobFile()
        {
            Id = uploadPath.First().Id,
            FilePath = uploadPath.First().Link,
            FileContent = uploadPath.First().ContentType,
        }, cancellationToken);
        await _dbContext.Products.AddAsync(data, cancellationToken);
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.ProductCreated),
        };
    }
}
