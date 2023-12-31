﻿using System.Text.Json.Serialization;
using Common.Constants;
using Common.Entities.Abstracts;

namespace Common.Events.Category;

public class CategoryCreatedEvent : EventStore<CategoryCreatedEventData>
{
    protected CategoryCreatedEvent() { }

    public CategoryCreatedEvent(string userId, Guid aggregateId, CategoryCreatedEventData data) : base(userId, aggregateId, 1, data)
    {
    }
}
public class CategoryCreatedEventData : IEventData
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid FileIdentifier { get; set; } = Guid.Empty;
    [JsonIgnore]
    public EventType Type => EventType.CategoryCreated;
}