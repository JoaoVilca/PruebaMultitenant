using Finbuckle.MultiTenant.Stores;
using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;

namespace MultitenantPrueba.Data
{
    public class AppDbContext : EFCoreStoreDbContext<TenantInfo>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("tenant-store");
            base.OnConfiguring(optionsBuilder);
        }
    }
}