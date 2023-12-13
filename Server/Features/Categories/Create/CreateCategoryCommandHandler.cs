using Common.Wrappers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Server.Features.Categories.Create;

public sealed record CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {

        return new MessageResponse()
        {
            Msg = "Category Created ! | "+request.Name+" "+request.Description,
        };

    }
}
