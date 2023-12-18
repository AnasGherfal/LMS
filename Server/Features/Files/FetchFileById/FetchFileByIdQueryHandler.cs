using Common.Exceptions;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace Server.Features.Files.FetchFileById;

public sealed record FetchFileByIdQueryHandler : IRequestHandler<FetchFileByIdQuery, FileStreamResult>
{
    private readonly AppDbContext _dbContext;

    public FetchFileByIdQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<FileStreamResult> Handle(FetchFileByIdQuery request, CancellationToken cancellationToken)
    {
        var document = await _dbContext.BlobFiles
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.FileId!), cancellationToken: cancellationToken);
        if (document == null) throw new NotFoundException("FILE_NOT_FOUND");
        if (!File.Exists(document.FilePath)) throw new NotFoundException("FILE_NOT_FOUND");
        var fileContents = await File.ReadAllBytesAsync(document.FilePath, cancellationToken);
        var stream = new MemoryStream(fileContents);
        return new FileStreamResult(stream, new MediaTypeHeaderValue(document.FileContent))
        {
            FileDownloadName = Path.GetFileName(document.FilePath)
        };
    }
}