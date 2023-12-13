namespace Infrastructure.Models;

public class BaseModel
{
    public short Status { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedById { get; set; }
    public bool Deleted { get; set; }
    public User CreatedBy { get; set; } = default!;
}