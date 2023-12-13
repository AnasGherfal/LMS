using Common.Wrappers;

namespace Server.Features.Categories.Delete;

public sealed record DeleteCategoryCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
