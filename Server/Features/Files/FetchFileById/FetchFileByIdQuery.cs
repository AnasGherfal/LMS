using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Features.Files.FetchFileById;
public sealed record FetchFileByIdQuery: IRequest<FileStreamResult>
{
    public string? FileId { get; set; }
}
