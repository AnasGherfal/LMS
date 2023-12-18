using Common.Constants;
using Common.Events.User;

namespace Common.Entities;

public class User: Entity
{
    public Guid Id { get; set; } = Guid.Empty;
    public string IdentityId { get; set; } = string.Empty;
    public string EmployeeNumber { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public SystemPermissions Permissions { get; set; }
    
    public void Apply(UserCreatedEvent @event)
    {
        Sequence = @event.Sequence;
        CreatedOn = @event.DateTime;
        UpdatedOn = @event.DateTime;
        Id = @event.AggregateId;
        IdentityId = @event.Data.IdentityId;
        EmployeeNumber = @event.Data.EmployeeNumber;
        DisplayName = @event.Data.DisplayName;
        Username = @event.Data.Username;
        Permissions = @event.Data.Permissions;
    }
}