using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Abstract;
using Server.Features.Files.FetchFileById;

namespace Server.Features.Files;

[AllowAnonymous]
[ApiController]
public class FilesController: ManagementController
{
    [HttpGet("{id}")]
    public async Task<FileStreamResult> FetchById(string id)
        => await Mediator.Send(new FetchFileByIdQuery()
        {
            FileId = id,
        });
}
