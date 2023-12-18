using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Builders;

public class ProductBuilder : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasQueryFilter(p => !p.IsDeleted);
        builder.HasKey(p => p.Id);
        builder.Property(p => p.CreatedOn).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(p => p.UpdatedOn).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(p => p.Sequence).IsRequired().HasDefaultValue(1);
        builder.Property(a => a.RowVersion).IsRequired().IsRowVersion();
        builder.Property(a => a.IsDeleted).IsRequired().HasDefaultValue(false);
        builder.ToTable("Products");
    }
}