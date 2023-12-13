namespace Infrastructure.Models;

public class User: BaseModel
{
    public Guid UserId { get; set; }
    public int EmpId { get; set; }
    public string UserName { get; set; } = default!;
    public string EmpCode { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string JobDesc { get; set; } = default!;
    public int EntityId { get; set; }
    public string? ActJobDesc { get; set; } = default!;
    public int? ActEntityId { get; set; }
    public short RoleId { get; set; }

    public Entity Entity { get; set; } = default!;
    public Entity? ActEntity { get; set; } = default!;
    public Role Role { get; set; } = default!;

    public List<User> UsersCreatedBy { get; set; } = default!;
    public List<Entity> EntitiesCreatedBy { get; set; } = default!;
    public List<Role> RolesCreatedBy { get; set; } = default!;
}

