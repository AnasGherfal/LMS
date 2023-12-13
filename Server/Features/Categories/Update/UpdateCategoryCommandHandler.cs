using Common.Wrappers;

namespace Server.Features.Categories.Update;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Category Updated!",
        };
    }
}
