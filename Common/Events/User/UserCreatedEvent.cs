using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.User;

public class UserCreatedEvent : EventStore<UserCreatedEventData>
{
    protected UserCreatedEvent() { }

    public UserCreatedEvent(string userId, Guid aggregateId, UserCreatedEventData data) : base(userId, aggregateId, 1, data)
    {
    }
}
public class UserCreatedEventData : IEventData
{
    public string IdentityId { get; set; } = string.Empty;
    public string EmployeeNumber { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public SystemPermissions Permissions { get; set; }
    [JsonIgnore]
    public EventType Type => EventType.UserCreated;
}