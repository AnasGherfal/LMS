using Common.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Server.Abstract;
using Server.Features.Products.Create;
using Server.Features.Products.Delete;
using Server.Features.Products.FetchAll;
using Server.Features.Products.Lock;
using Server.Features.Products.Unlock;
using Server.Features.Products.Update;
using Server.Features.Products.FetchById;


namespace Server.Controllers.Management;

[AllowAnonymous]
[ApiController]
public class ProductsController: ManagementController
{
    [HttpPost]
    public async Task<MessageResponse> Create([FromForm] CreateProductCommand request){
        return await Mediator.Send(request);
    }


    [HttpPut("{id}")]

    public async Task<MessageResponse> Update( string id, [FromBody] UpdateProductCommand request){
        request.SetId(id);
        return await Mediator.Send(request);

    }

    [HttpDelete("{id}")]
    public async Task<MessageResponse> Delete(string id)
        => await Mediator.Send(new DeleteProductCommand()
        {
            Id = id,
        });

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

// fetch All Products
        [HttpGet("/fetch")]
    public async Task<PagedResponse<FetchProductsQueryResponse>> Fetch([FromQuery] FetchProductsQuery request)
        => await Mediator.Send(request);

// fetch Certain Products
      //[HttpGet("{id}")]
/* public async Task<ContentResponse<FetchProductByIdQuery>> FetchProductById(string id, [FromQuery] FetchProductByIdQuery request)
{
    
    return await Mediator.Send(request);
} */



}

