namespace Infrastructure.Models;

public class Role: BaseModel
{
    public short Id { get; set; }
    public string Name { get; set; } = default!;
    public IList<User> Users { get; set; } = default!;
}

