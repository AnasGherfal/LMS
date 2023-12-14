using Common.Wrappers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Server.Features.Products.Create;

public sealed record CreateProductCommandHandler : IRequestHandler<CreateProductCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
return new MessageResponse{

        Msg = "product Created ",
    };    
        }
}