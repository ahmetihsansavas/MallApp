using MallApp.Business.Abstract;
using MallApp.Business.Concrete;
using MallApp.DataAccess.Abstract;
using MallApp.DataAccess.Concrete.EfCore;
using MallApp.DataAccess.Concrete.Memory;
using MallApp.WebUI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MallApp.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //IProduct EfCoreProductDal
            services.AddScoped<IProductDal, EfCoreProductDal>();
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService,CategoryManager>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/modules"
            });
            app.CustomStaticFiles();
           // app.UseRouting();
           // app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"
                 );
                routes.MapRoute(
                name: "products",
                template: "products/{category?}",
                defaults : new {controller = "Shop" , action ="List" }
               );
                routes.MapRoute(
                name: "Shop",
                template: "Shop/List/{text?}",
                defaults: new { controller = "Shop", action = "List" }
                );
            


            }
                   
            
            );
         
        }
    }
}
