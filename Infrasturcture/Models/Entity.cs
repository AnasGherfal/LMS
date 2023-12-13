namespace Infrastructure.Models;

public class Entity: BaseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public virtual IList<User> Users { get; set; } = default!;

}

