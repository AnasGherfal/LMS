using Common;

namespace Infrastructure.Models;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Contact { get; set; } = default!;

}
