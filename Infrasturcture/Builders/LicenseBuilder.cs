using Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Builders;

public class LicenseBuilder : IEntityTypeConfiguration<License>
{
    public void Configure(EntityTypeBuilder<License> builder)
    {
        builder.HasQueryFilter(p => !p.IsDeleted);
        builder.HasKey(p => p.Id);
        builder.Property(p => p.CreatedOn).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(p => p.UpdatedOn).IsRequired().HasDefaultValue(DateTime.UtcNow);
        builder.Property(p => p.Sequence).IsRequired().HasDefaultValue(1);
        builder.Property(a => a.RowVersion).IsRequired().IsRowVersion();
        builder.Property(a => a.IsDeleted).IsRequired().HasDefaultValue(false);
        builder.ToTable("Licenses");
    }
}
