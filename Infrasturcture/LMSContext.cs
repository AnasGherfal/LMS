using Infrastructure.Models;

namespace Infrastructure;

public class LMSContext : DbContext
{
    public LMSContext(DbContextOptions<LMSContext> options) : base(options) { }

    public DbSet<Entity> Entities { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<License> Licenses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(LMSContext).Assembly);
    }
}
