using System.Security.Claims;
using Common.Constants;
using Common.Entities;
using Common.Entities.Abstracts;
using Common.Events.Category;
using Common.Exceptions;
using Common.Services;
using Common.Services.Dtos;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Categories.Create;

public sealed record CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, MessageResponse>
{
    private readonly IClientService _client;
    private readonly IUploadFileService _uploadFile;
    private readonly AppDbContext _dbContext;

    public CreateCategoryCommandHandler(AppDbContext dbContext, IUploadFileService uploadFile, IClientService client)
    {
        _dbContext = dbContext;
        _uploadFile = uploadFile;
        _client = client;
    }

    public async Task<MessageResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var nameExists = await _dbContext.Categories.AnyAsync(p => p.Name == request.Name!, cancellationToken: cancellationToken);
        if (nameExists) throw new BadRequestException(nameof(Locale.CategoryNameExists));
        var fileRequests = new List<FileStorageUploadRequest>()
        {
            new(Guid.NewGuid(), request.Photo!),
        };
        var uploadPath = await _uploadFile.UploadFiles(fileRequests);
        if (uploadPath == null) throw new BadRequestException(nameof(Locale.CategoryPhotoUploadField));
        var @event = new CategoryCreatedEvent(_client.IdentityId, Guid.NewGuid(), new CategoryCreatedEventData()
        {
            Name = request.Name!,
            Description = request.Description!,
            FileIdentifier = uploadPath.First().Id,
        });
        var data = new Category();
        data.Apply(@event);
        await _dbContext.BlobFiles.AddAsync(new BlobFile()
        {
            Id = uploadPath.First().Id,
            FilePath = uploadPath.First().Link,
            FileContent = uploadPath.First().ContentType,
        }, cancellationToken);
        await _dbContext.Categories.AddAsync(data, cancellationToken);
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.CategoryCreated),
        };
    }
}
