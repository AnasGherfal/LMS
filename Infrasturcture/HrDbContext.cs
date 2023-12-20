using Microsoft.EntityFrameworkCore;
using Common.Entities.HrEntities;

namespace Infrastructure
{
    public sealed class HrDbContext : DbContext
    {
        public DbSet<AdminEntity> AdminEntities => Set<AdminEntity>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<ManagementPostion> ManagementPostions => Set<ManagementPostion>();

        public HrDbContext(DbContextOptions<HrDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEntity>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<Employee>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<ManagementPostion>(entity => { entity.HasNoKey(); });
            base.OnModelCreating(modelBuilder);
        }
        
        [Obsolete("This context is read-only", true)]
        public new int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new int SaveChanges(bool acceptAll)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new Task<int> SaveChangesAsync(bool acceptAll, CancellationToken token = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }
    }
}
 


      
