using BLNorthWind.BL;
using DALNorthWind.Data;
using DALNorthWind.Models;
using DALNorthWind.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NorthWind.Models.Data;

namespace NorthWind
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbCon")));
            services.AddScoped<IRepository<Customer>, DALCustomers>();
            services.AddScoped<IBLWorkService<Customer>, BLCustomers>();
            services.AddScoped<IRepository<Order>, DALOrder>();
            services.AddScoped<IBLWorkService<Order>, BLOrder>();
            services.AddScoped<IRepository<Product>, DALProduct>();
            services.AddScoped<IBLWorkService<Product>, BLProduct>();
            services.AddScoped<IRepository<Supplier>, DALSupplier>();
            services.AddScoped<IBLWorkService<Supplier>, BLSupplier>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                  name: "Identity",
                  areaName: "Identity",
                  pattern: "Identity/{controller=Account}/{action=Login}");
                endpoints.MapRazorPages();
            });
        }
    }
}
