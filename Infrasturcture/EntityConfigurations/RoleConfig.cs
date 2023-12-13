using Common;
using Infrastructure.Models;

namespace Infrastructure.EntityConfigurations;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Deleted).HasDefaultValue(0);
        builder.Property(e => e.Status).HasDefaultValue(Status.Active);

        builder.HasOne(a => a.CreatedBy)
     .WithMany(u => u.RolesCreatedBy)
     .HasForeignKey(a => a.CreatedById)
     .OnDelete(DeleteBehavior.ClientSetNull);
    }
}