using Common.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Abstract;
using Server.Features.Products.Create;
using Server.Features.Products.Delete;
using Server.Features.Products.FetchAll;
using Server.Features.Products.FetchById;
using Server.Features.Products.Lock;
using Server.Features.Products.Unlock;
using Server.Features.Products.Update;

namespace Server.Features.Products;

[AllowAnonymous]
[ApiController]
public class ProductsController: ManagementController
{
    [HttpPost]
    public async Task<MessageResponse> Create([FromForm] CreateProductCommand request)
        => await Mediator.Send(request);

    [HttpGet]
    public async Task<PagedResponse<FetchProductsQueryResponse>> Fetch([FromQuery] FetchProductsQuery request)
        => await Mediator.Send(request);
    
    [HttpGet("{id}")]
    public async Task<ContentResponse<FetchProductByIdQueryResponse>> FetchById(string id)
        => await Mediator.Send(new FetchProductByIdQuery()
        {
            Id = id,
        });
    
    
    [HttpPut("{id}")]
    public async Task<MessageResponse> Update(string id, [FromBody] UpdateProductCommand request)
    {
        request.SetId(id);
        return await Mediator.Send(request);
    }

    [HttpPut("{id}/lock")]
    public async Task<MessageResponse> Lock(string id)
        => await Mediator.Send(new LockProductCommand()
        {
            Id = id,
        });

    [HttpPut("{id}/unlock")]
    public async Task<MessageResponse> UnLock(string id)
        => await Mediator.Send(new UnlockProductCommand()
        {
            Id = id,
        });

    [HttpDelete("{id}")]
    public async Task<MessageResponse> Delete(string id)
        => await Mediator.Send(new DeleteProductCommand()
        {
            Id = id,
        });
}
