using Common.Wrappers;

namespace Server.Features.Products.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Product Updated!",
        };
    }
}
