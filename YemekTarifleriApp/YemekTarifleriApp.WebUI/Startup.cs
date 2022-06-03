using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YemekTarifleriApp.Bussiness.Abstract;
using YemekTarifleriApp.Bussiness.Concrete;
using YemekTarifleriApp.Data.Abstract;
using YemekTarifleriApp.Data.Concrete.EFCore;

namespace YemekTarifleriApp.WebUI
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
            services.AddScoped<IRecipeRepository, EFCoreRecipeRepository>();
            services.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();
            services.AddScoped<IRecipeService, RecipeManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IMemberRepository, EFCoreMemberRepository>();
            services.AddScoped<IMemberService, MemberManager>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "adminmembercreate",
                   pattern: "admin/membercreate/create",
                   defaults: new { controller = "Admin", action = "MemberCreate" }
                   );

                endpoints.MapControllerRoute(
                   name: "admincategories",
                   pattern: "admin/memberlist",
                   defaults: new { controller = "Admin", action = "MemberList" }
                   );

                endpoints.MapControllerRoute(
                   name: "adminmemberedit",
                   pattern: "admin/memberedit/{id?}",
                   defaults: new { controller = "Admin", action = "MemberEdit" }
                   );
                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/categorycreate/create",
                    defaults: new { controller = "Admin", action = "CategoryCreate" }
                    );

                endpoints.MapControllerRoute(
                   name: "admincategories",
                   pattern: "admin/categorylist",
                   defaults: new { controller = "Admin", action = "CategoryList" }
                   );

                endpoints.MapControllerRoute(
                   name: "admincategoryedit",
                   pattern: "admin/categoryedit/{id?}",
                   defaults: new { controller = "Admin", action = "CategoryEdit" }
                   );

                endpoints.MapControllerRoute(
                    name: "adminrecipecreate",
                    pattern: "admin/recipecreate/create",
                    defaults: new { controller = "Admin", action = "RecipeCreate" }
                    );

                endpoints.MapControllerRoute(
                    name: "adminrecipes",
                    pattern: "admin/recipelist",
                    defaults: new { controller = "Admin", action = "RecipeList" }
                    );

                endpoints.MapControllerRoute(
                   name: "search",
                   pattern: "search",
                   defaults: new { controller = "YemekTarifleriApp", action = "Search" }
                   );

                endpoints.MapControllerRoute(
                   name: "recipes",
                   pattern: "recipes/{category?}",
                   defaults: new { controller = "YemekTarifleriApp", action = "List" }
                   );

                endpoints.MapControllerRoute(
                   name: "adminrecipeedit",
                   pattern: "admin/recipeedit/{id?}",
                   defaults: new { controller = "Admin", action = "RecipeEdit" }
                   );

                endpoints.MapControllerRoute(
                   name: "recipedetails",
                   pattern: "{url}",
                   defaults: new { controller = "YemekTarifleriApp", action = "Details" }
                   );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
