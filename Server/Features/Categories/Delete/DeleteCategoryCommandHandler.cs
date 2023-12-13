using Common.Wrappers;

namespace Server.Features.Categories.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        return new MessageResponse()
        {
            Msg = "Category Deleted!",
        };

    }
}
