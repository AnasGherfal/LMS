using Common.Wrappers;

namespace Server.Features.Products.Delete;

public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Category Deleted!",
        };

    }
}
