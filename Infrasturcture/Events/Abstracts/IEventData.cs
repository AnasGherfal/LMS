using Common.Constants;
using System.Text.Json.Serialization;

namespace Infrastructure.Events.Abstracts;

public interface IEventData
{
    [JsonIgnore]
    EventType Type { get; }
}