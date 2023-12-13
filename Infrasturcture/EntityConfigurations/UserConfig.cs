using Common;
using Infrastructure.Models;

namespace Infrastructure.EntityConfigurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e => e.UserId).ValueGeneratedNever();
        builder.Property(e => e.UserName).HasMaxLength(150);
        builder.Property(e => e.FullName).HasMaxLength(150);
        builder.Property(e => e.JobDesc).HasMaxLength(200);
        builder.Property(e => e.ActJobDesc).HasMaxLength(200);
        builder.Property(e => e.JobDesc).HasMaxLength(250);
        builder.Property(e => e.Deleted).HasDefaultValue(0);
        builder.Property(e => e.EmpCode).HasColumnType("char(4)");
        builder.Property(e => e.Status).HasDefaultValue(Status.Active);
        
        builder.HasOne(s => s.Role)
         .WithMany(j => j.Users)
         .HasForeignKey(s => s.RoleId)
         .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(s => s.Entity)
         .WithMany(j => j.Users)
         .HasForeignKey(s => s.EntityId)
         .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(a => a.CreatedBy)
         .WithMany(u => u.UsersCreatedBy)
         .HasForeignKey(a => a.CreatedById)
         .OnDelete(DeleteBehavior.ClientSetNull);
    }
}