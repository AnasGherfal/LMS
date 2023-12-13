using Infrastructure.Models;

namespace Infrastructure.EntityConfigurations;

public class EntityConfig : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Deleted).HasDefaultValue(0);

        builder.HasOne(a => a.CreatedBy)
       .WithMany(u => u.EntitiesCreatedBy)
       .HasForeignKey(a => a.CreatedById)
       .OnDelete(DeleteBehavior.ClientSetNull);
    }
}