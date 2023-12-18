using System.Text.Json.Serialization;
using Common.Constants;

namespace Common.Entities.Abstracts;

public interface IEventData
{
    [JsonIgnore]
    EventType Type { get; }
}