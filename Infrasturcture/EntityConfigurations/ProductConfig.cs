using Infrastructure.Models;

namespace Infrastructure.EntityConfigurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

    }
}