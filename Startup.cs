using INTEX2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace INTEX2
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

            services.AddDbContext<AccidentsDbContext>(options =>
            {
                options.UseMySql(Configuration["ConnectionStrings:AccidentsDbConnection"]);
            });



            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AppIdentityDBContext>(options =>
                options.UseSqlite(Configuration["ConnectionStrings:IdentityConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDBContext>();

            services.AddScoped<IAccidentsRepository, EFAccidentsRepository>();

            services.AddSingleton<InferenceSession>(
                new InferenceSession("intex (3).onnx"));


            services.AddRazorPages();
            services.AddServerSideBlazor();

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
            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();


            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Security-Policy-Report-Only", "default-src 'self'");
                await next();
            });

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute("Paging",
                    "Page{pageNum}",
                    new { Controller = "Home", Action = "Accidents", pageNum = 1});

                endpoints.MapControllerRoute("PagingFilter",
                    "Page{pageNum}/Motorcycle{motorcycle}/Pedestrian{pedestrian}/Overturn{overturn}/Bicyclist{bicyclist}/" +
                    "Unrestrained{unrestrained}/Intersection{intersection}/DUI{dui}/Night{night}/RoadwayDeparture{roadwaydeparture}/" +
                    "SingleVehicle{singlehevicle}",
                    new { Controller = "Home", Action = "Accidents", pageNum = 1, motorcycle = 0, pedestrian = 0, overturn = 0, 
                        bicyclist = 0, unrestrained = 0, intersection = 0, dui = 0, night = 0, roadwaydeparture = 0, singlevehicle = 0 });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();

                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

            });

            IdentitySeedData.EnsurePopulated(app);


        }
    }
}
