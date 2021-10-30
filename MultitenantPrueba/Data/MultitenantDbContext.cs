using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantPrueba.Data
{
    public class MultitenantDbContext : EFCoreStoreDbContext<TenantInfo>
    {
        public MultitenantDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EFCoreStoreSampleConnectionString");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
