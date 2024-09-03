using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Security.Policy;
using System.Xml.Linq;

namespace DB
{

    public class AcreaContext : DbContext
    {
        public AcreaContext(DbContextOptions<AcreaContext> options) : base(options)
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ComponentOrder> ComponentOrders { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Client>()
                .Property(c => c.Id)
                .HasColumnType("INTEGER")
                .IsRequired();

            modelBuilder.Entity<ComponentType>()
                .HasKey(ct => ct.Id);

            modelBuilder.Entity<Component>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Component>()
                .HasOne(c => c.CComponentType)
                .WithMany()
                .HasForeignKey(c => c.Type);
           

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OClient)
                .WithMany()
                .HasForeignKey(o => o.Client);

            modelBuilder.Entity<ComponentOrder>()
                .HasKey(co => new { co.OrderId, co.ComponentId });

            modelBuilder.Entity<ComponentOrder>()
                .HasOne(co => co.Order)
                .WithMany(o => o.ComponentOrders)
                .HasForeignKey(co => co.OrderId);

            modelBuilder.Entity<ComponentOrder>()
                .HasOne(co => co.Component)
                .WithMany()
                .HasForeignKey(co => co.ComponentId);

            modelBuilder.Entity<Status>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
           

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        
    }
}


    



