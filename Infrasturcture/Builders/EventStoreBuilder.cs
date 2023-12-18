using Common.Constants;
using Common.Entities.Abstracts;
using Common.Events.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Builders;

public static class EventStoreBuilder
{
    public static void AddEventBuilder(this DbContext dbContext,  ModelBuilder builder)
    {
        builder.Entity<Event>(b => {
             b.HasKey(p => p.Id);
            b.HasIndex(p => new
            {
                p.AggregateId,
                p.DateTime,
            }).IsUnique();
            b.HasDiscriminator(e => e.Type)
                .HasValue<CategoryCreatedEvent>(EventType.CategoryCreated)
                .HasValue<CategoryUpdatedEvent>(EventType.CategoryUpdated)
                .HasValue<CategoryDeletedEvent>(EventType.CategoryDeleted)
                .HasValue<CategoryLockedEvent>(EventType.CategoryLocked)
                .HasValue<CategoryUnlockedEvent>(EventType.CategoryUnlocked)
                ;
            b.ToTable("EventStore");
        });
        builder.ApplyConfiguration(new EventStoreConfiguration<CategoryCreatedEvent, CategoryCreatedEventData>());
        builder.ApplyConfiguration(new EventStoreConfiguration<CategoryUpdatedEvent, CategoryUpdatedEventData>());
        builder.ApplyConfiguration(new EventStoreConfiguration<CategoryDeletedEvent, CategoryDeletedEventData>());
        builder.ApplyConfiguration(new EventStoreConfiguration<CategoryLockedEvent, CategoryLockedEventData>());
        builder.ApplyConfiguration(new EventStoreConfiguration<CategoryUnlockedEvent, CategoryUnlockedEventData>());
    }
}

public class EventStoreConfiguration<T, TData> : IEntityTypeConfiguration<T> where T : EventStore<TData> where TData : IEventData
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(e => e.Data).HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<TData>(v)!
        ).HasColumnName("Content");
    }
}