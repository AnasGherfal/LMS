using Common.Entities.Abstracts;
using Common.Entities;
using Infrastructure.Builders;
using Infrastructure.HrModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{


    public class HRMSContext : DbContext
    {
        public DbSet<AdminEntity> AdminEntities => Set<AdminEntity>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<ManagementPostion> ManagementPostions => Set<ManagementPostion>();

        public HRMSContext(DbContextOptions<HRMSContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEntity>(entity =>
            {
                entity.HasNoKey( );  } );

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<ManagementPostion>(entity =>
            {
                entity.HasNoKey();
            });
            base.OnModelCreating(modelBuilder);


        }

        } 
    }
 


      
