using Common.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Server.Abstract;
using Server.Features.Licenses.Create;
using Server.Features.Licenses.Delete;
using Server.Features.Licenses.FetchAll;
using Server.Features.Licenses.Lock;
using Server.Features.Licenses.Unlock;
using Server.Features.Licenses.Update;

namespace Server.Features.Licenses;

[AllowAnonymous]
[ApiController]
public class LicensesController: ManagementController
{
    [HttpPost]
    public async Task<MessageResponse> Create([FromForm] CreateLicenseCommand request)
        => await Mediator.Send(request);

    [HttpGet]
    public async Task<PagedResponse<FetchLicensesQueryResponse>> Fetch([FromQuery] FetchLicensesQuery request)
        => await Mediator.Send(request);
    
    
    [HttpPut("{id}")]
    public async Task<MessageResponse> Update(string id, [FromBody] UpdateLicenseCommand request)
    {
        request.SetId(id);
        return await Mediator.Send(request);
    }

    [HttpPut("{id}/lock")]
    public async Task<MessageResponse> Lock(string id)
        => await Mediator.Send(new LockLicenseCommand()
        {
            Id = id,
        });

    [HttpPut("{id}/unlock")]
    public async Task<MessageResponse> UnLock(string id)
        => await Mediator.Send(new UnlockLicenseCommand()
        {
            Id = id,
        });

    [HttpDelete("{id}")]
    public async Task<MessageResponse> Delete(string id)
        => await Mediator.Send(new DeleteLicenseCommand()
        {
            Id = id,
        });
}
