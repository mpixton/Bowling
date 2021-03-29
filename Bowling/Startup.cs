using Bowling.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling
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

            // Add DbContext to the Project.
            services.AddDbContext<BowlingDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BowlingConnection"]);
            });

            // Provide the UnitOfWork to the Dependecy Injection container.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Map new routes.
            app.UseEndpoints(endpoints =>
            {
                // Route if just the page is provided.
                endpoints.MapControllerRoute(
                    name: "page",
                    pattern: "Bowlers/{pageNum}",
                    new {Controller = "Home", action ="Index"}
                    );
                // Route if just the team is provided.
                endpoints.MapControllerRoute(
                    name: "team",
                    pattern: "{team}",
                    new {Controller = "Home", action = "Index"}
                    );
                // Route is both parameters are provided.
                endpoints.MapControllerRoute(
                    name: "teamAndPage",
                    pattern: "{team}/{pageNum}",
                    new {Controller = "Home", action = "Index"}
                    );
                // Route for the home page.
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "",
                    new {Controller = "Home", action = "Index"}
                    );
            });
        }
    }
}
