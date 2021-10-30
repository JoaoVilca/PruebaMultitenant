using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using MultitenantPrueba.Models;

namespace MultitenantPrueba.Data
{
    public class SampleContext : MultiTenantDbContext
    { 
        public SampleContext(TenantInfo tenantInfo) : base(tenantInfo) { }
        public SampleContext(TenantInfo tenantInfo, DbContextOptions<SampleContext> options) : base(tenantInfo, options) {  }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(TenantInfo.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        //Uncomment to create database
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string connectionString = "Server=localhost;Port=5432;Database=Tenant;User Id=postgres;Password=9780btc01;pooling=true";
        //        //optionsBuilder.UseNpgsql(connectionString.Replace("{tenant}", "Tenant"));
        //        optionsBuilder.UseNpgsql(connectionString);
        //    }
        //}
    }
}