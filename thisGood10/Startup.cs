using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using thisGood10.Models;
using thisGood10.Models.Repositories.EntityFrameworks;
using thisGood10.Models.Repositories.Interfaces;

namespace thisGood10
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        private IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(opts => {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:thisGood"]);
            });


            

            //регестрируем репозиторий
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<IPersonRepository, EFPersonRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<ISketchRepository, EFSketchRepository>();
            services.AddScoped<DataManager>();
            //Создаём Razor страницы
            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();
            app.UseEndpoints(endpoints => {
                //делаем понятный URL адрес              
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("catpage", "{categoryName}/Page{sketchPage:int}",  
                    new { Controller = "Home", action = "sketchesProducts" });
                endpoints.MapControllerRoute("page", "Page{sketchPage:int}",                    
                    new { Controller = "Home", action = "sketchesProducts", productPage = 1 });
                endpoints.MapControllerRoute("category", "{categoryName}",                      
                    new { Controller = "Home", action = "sketchesProducts", productPage = 1 });
                endpoints.MapControllerRoute("pagination", "Sketches/Page{sketchPage:int}",    
                    new { Controller = "Home", action = "sketchesProducts", productPage = 1 });

                endpoints.MapDefaultControllerRoute();

                //Razor
                endpoints.MapRazorPages();

            });
                
                
            SeedData.EnsurePopulated(app);
        }
    }
}


