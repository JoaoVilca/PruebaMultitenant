using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MultitenantPrueba.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitenantPrueba
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.ConfigureMultitenant();
            services.AddControllers();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MultitenantPrueba", Version = "v1" });
            });
            //var coneccion = Configuration.GetConnectionString("connectionTemplate");
            ////services.AddEntityFrameworkNpgsql().AddDbContext<NpgsqlDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("NpgSqlConnection")));
            //services.AddDbContext<SampleContext>(options => options.UseNpgsql(coneccion));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MultitenantPrueba v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMultitenantTenant();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{__tenant__=}/{controller=WeatherForecast}/{action=Get}");
            });

            //SetupStore(app.ApplicationServices);
        }
        //private void SetupStore(IServiceProvider sp)
        //{
        //    var scopeServices = sp.CreateScope().ServiceProvider;
        //    var store = scopeServices.GetRequiredService<IMultiTenantStore<TenantInfo>>();

        //    store.TryAddAsync(new TenantInfo { Id = "tenant-finbuckle-241", Identifier = "finbuckle", Name = "Finbuckle", ConnectionString = "finbuckle_conn_string" }).Wait();
        //    store.TryAddAsync(new TenantInfo { Id = "tenant-initech-235", Identifier = "initech", Name = "Initech LLC", ConnectionString = "initech_conn_string" }).Wait();
        //}
    }
}
