using System.Text.Json.Serialization;
using Common.Constants;

namespace Common.Events.Abstracts;

public interface IEventData
{
    [JsonIgnore]
    EventType Type { get; }
}