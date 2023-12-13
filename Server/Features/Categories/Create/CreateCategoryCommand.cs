using Common.Wrappers;

namespace Server.Features.Categories.Create;

public sealed record CreateCategoryCommand: IRequest<MessageResponse>
{
    public string? Name { get; set; }
    public string? Description { get; set; }

}
