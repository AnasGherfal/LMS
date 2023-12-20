using Common.Wrappers;
using Infrastructure.HrModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Abstract;
using Server.Features.Departments.Create;
using Server.Features.Departments.Delete;
using Server.Features.Departments.FetchAll;
using Server.Features.Departments.GetDepartments;
using Server.Features.Departments.Lock;
using Server.Features.Departments.Unlock;
using Server.Features.Departments.Update;

namespace Server.Features.Departments;

[AllowAnonymous]
[ApiController]
public class DepartmentsController: ManagementController
{
    [HttpPost]
    public async Task<MessageResponse> Create([FromForm] CreateDepartmentCommand request)
        => await Mediator.Send(request);

    [HttpGet]
    public async Task<PagedResponse<FetchDepartmentsQueryResponse>> Fetch([FromQuery] FetchDepartmentsQuery request)
        => await Mediator.Send(request);


 
    [HttpGet("all", Name = "GetAllDepartments")]
    public async Task<ActionResult<List<GetDepartmentsQueryResponse>>> GetDepartments()
    {
        var dtos = await Mediator.Send(new GetDepartmentsQuery());
        return Ok(dtos);
    }


    [HttpPut("{id}")]
    public async Task<MessageResponse> Update(string id, [FromBody] UpdateDepartmentCommand request)
    {
        request.SetId(id);
        return await Mediator.Send(request);
    }

    [HttpPut("{id}/lock")]
    public async Task<MessageResponse> Lock(string id)
        => await Mediator.Send(new LockDepartmentCommand()
        {
            Id = id,
        });

    [HttpPut("{id}/unlock")]
    public async Task<MessageResponse> UnLock(string id)
        => await Mediator.Send(new UnlockDepartmentCommand()
        {
            Id = id,
        });

    [HttpDelete("{id}")]
    public async Task<MessageResponse> Delete(string id)
        => await Mediator.Send(new DeleteDepartmentCommand()
        {
            Id = id,
        });
}
