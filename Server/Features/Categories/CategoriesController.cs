using Common.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Server.Abstract;
using Server.Features.Categories.Create;
using Server.Features.Categories.Delete;
using Server.Features.Categories.FetchAll;
using Server.Features.Categories.FetchById;
using Server.Features.Categories.Lock;
using Server.Features.Categories.Unlock;
using Server.Features.Categories.Update;

namespace Server.Features.Categories;

[AllowAnonymous]
[ApiController]
public class CategoriesController: ManagementController
{
    [HttpPost]
    public async Task<MessageResponse> Create([FromForm] CreateCategoryCommand request)
        => await Mediator.Send(request);

    [HttpGet]
    public async Task<PagedResponse<FetchCategoriesQueryResponse>> Fetch([FromQuery] FetchCategoriesQuery request)
        => await Mediator.Send(request);
    
    [HttpGet("{id}")]
    public async Task<ContentResponse<FetchCategoryQueryResponse>> FetchById(string id)
        => await Mediator.Send(new FetchCategoryQuery()
        {
            Id = id,
        });
    
    
    [HttpPut("{id}")]
    public async Task<MessageResponse> Update(string id, [FromBody] UpdateCategoryCommand request)
    {
        request.SetId(id);
        return await Mediator.Send(request);
    }

    [HttpPut("{id}/lock")]
    public async Task<MessageResponse> Lock(string id)
        => await Mediator.Send(new LockCategoryCommand()
        {
            Id = id,
        });

    [HttpPut("{id}/unlock")]
    public async Task<MessageResponse> UnLock(string id)
        => await Mediator.Send(new UnlockCategoryCommand()
        {
            Id = id,
        });

    [HttpDelete("{id}")]
    public async Task<MessageResponse> Delete(string id)
        => await Mediator.Send(new DeleteCategoryCommand()
        {
            Id = id,
        });
}
