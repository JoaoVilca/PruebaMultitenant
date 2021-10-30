using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MultitenantPrueba.Data;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class ConfigureTenant
    {
        public static void ConfigureMultitenant(this IServiceCollection services)
        {
            
            services.AddMultiTenant<TenantInfo>()
                    .WithEFCoreStore<AppDbContext, TenantInfo>()
                    .WithStaticStrategy("tenant-b");
            services.AddDbContext<SampleContext>();
        }
        public static void UseMultitenantTenant(this IApplicationBuilder app)
        {
            app.UseMultiTenant();
            SetupStore(app.ApplicationServices);
        }
         
        private static void SetupStore(IServiceProvider serviceProvider)
        {
            var scopeServices = serviceProvider.CreateScope().ServiceProvider;
            var store = scopeServices.GetRequiredService<IMultiTenantStore<TenantInfo>>();

            store.TryAddAsync(new TenantInfo { Id="tenant-a-d043favoiaw", Identifier="tenant-a", Name="Tenant LLC", ConnectionString="Server=localhost;Port=5432;Database=TenantA;Trusted_Connection=True;MultipleActiveResultSets=true" }).Wait();
            store.TryAddAsync(new TenantInfo { Id="tenant-b-341ojadsfa", Identifier="tenant-b", Name="Tenant LLC", ConnectionString="Server=localhost;Port=5432;Database=TenantB;Trusted_Connection=True;MultipleActiveResultSets=true" }).Wait();
        }
    }
}
