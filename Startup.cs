using INTEX2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddScoped<IAccidentsRepository, EFAccidentsRepository>();


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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("MonthDayHourPaging",
                //    "{controller=Home}/{action=Accidents}/{month}/{day}/Hour{hour}/Page{pageNum}",
                //    new { Controller = "Home", Action = "Accidents", pageNum = 1 });

                //endpoints.MapControllerRoute("MonthDayPaging",
                //    "{controller=Home}/{action=Accidents}/{month}/{day}/Page{pageNum}",
                //    new { Controller = "Home", Action = "Accidents", pageNum = 1 });

                //endpoints.MapControllerRoute("MonthHourPaging",
                //    "{controller=Home}/{action=Accidents}/{month}/Hour{hour}/Page{pageNum}",
                //    new { Controller = "Home", Action = "Accidents", pageNum = 1 });

                //endpoints.MapControllerRoute("DayHourPaging",
                //    "{controller=Home}/{action=Accidents}/{day}/Hour{hour}/Page{pageNum}",
                //    new { Controller = "Home", Action = "Accidents", pageNum = 1 });

                //endpoints.MapControllerRoute("MonthPaging",
                //    "{controller=Home}/{action=Accidents}/{month}/Page{pageNum}",
                //    new { Controller = "Home", Action = "Accidents", pageNum = 1 });

                endpoints.MapControllerRoute("DayPaging",
                    "{controller=Home}/{action=Accidents}/{day}/Page{pageNum}",
                    new { Controller = "Home", Action = "Accidents", pageNum = 1 });

                //endpoints.MapControllerRoute("HourPaging",
                //    "{controller=Home}/{action=Accidents}/Hour{hour}/Page{pageNum}",
                //    new { Controller = "Home", Action = "Accidents", pageNum = 1 });

                endpoints.MapControllerRoute("Paging",
                    "Page{pageNum}",
                    new { Controller = "Home", Action = "Accidents", pageNum = 1});

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
