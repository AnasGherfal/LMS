using Common.Constants;
using Common.Events.Category;

namespace Common.Entities;

public class Category: Entity
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid Photo { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = [];
    public EntityStatus Status { get; set; }
    
    public void Apply(CategoryCreatedEvent @event)
    {
        Sequence = @event.Sequence;
        CreatedOn = @event.DateTime;
        UpdatedOn = @event.DateTime;
        Id = @event.AggregateId;
        Name = @event.Data.Name;
        Description = @event.Data.Description;
        Photo = @event.Data.FileIdentifier;
        Status = EntityStatus.Active;
    }
    
    public void Apply(CategoryUpdatedEvent @event)
    {
        Name = @event.Data.Name ?? Name;
        Description = @event.Data.Description ?? Description;
        Photo = @event.Data.FileIdentifier ?? Photo;
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
    }

    public void Apply(CategoryLockedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        Status = EntityStatus.Locked;
    }
    
    public void Apply(CategoryUnlockedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        Status = EntityStatus.Active;
    }
    
    public void Apply(CategoryDeletedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        IsDeleted = true;
    }
}