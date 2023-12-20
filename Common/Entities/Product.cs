using Common.Constants;
using Common.Events.Category;
using Common.Events.Product;

namespace Common.Entities;

public class Product: Entity
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid CategoryId { get; set; }
    public Guid Photo { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public EntityStatus Status { get; set; }
    public Category? Category { get; set; }
    public ICollection<License> Licenses { get; set; } = default!;

    public void Apply(ProductCreatedEvent @event)
    {
        Sequence = @event.Sequence;
        CreatedOn = @event.DateTime;
        UpdatedOn = @event.DateTime;
        Id = @event.AggregateId;
        CategoryId = @event.Data.CategoryId;
        Name = @event.Data.Name;
        Description = @event.Data.Description;
        Provider = @event.Data.Provider;
        Photo = @event.Data.FileIdentifier;
        Status = EntityStatus.Active;
    }
    
    public void Apply(ProductUpdatedEvent @event)
    {
        Name = @event.Data.Name ?? Name;
        Description = @event.Data.Description ?? Description;
        Provider = @event.Data.Provider ?? Provider;
        Photo = @event.Data.FileIdentifier ?? Photo;
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
    }

    public void Apply(ProductLockedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        Status = EntityStatus.Locked;
    }
    
    public void Apply(ProductUnlockedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        Status = EntityStatus.Active;
    }
    
    public void Apply(ProductDeletedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        IsDeleted = true;
    }
}