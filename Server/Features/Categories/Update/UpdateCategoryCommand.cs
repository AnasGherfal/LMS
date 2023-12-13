using Common.Wrappers;

namespace Server.Features.Categories.Update;

public sealed record UpdateCategoryCommand : IRequest<MessageResponse>
{
    public string? Id { get; private set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IFormFile? Icon { get; set; }

    public void SetId(string id)
    {
        Id = id;
    }

}
