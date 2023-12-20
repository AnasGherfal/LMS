using Common.Entities;
using Common.Entities.Abstracts;
using Infrastructure.Builders;
using Microsoft.EntityFrameworkCore;
using File = System.IO.File;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<BlobFile> BlobFiles => Set<BlobFile>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<License> Licenses => Set<License>();
    public DbSet<Product> Products => Set<Product>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected AppDbContext(DbContextOptions options)
      : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.AddEventBuilder(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
