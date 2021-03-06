﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FishWaters.Data;

namespace FishWaters
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

            //services.AddMvc();
            services.AddRazorPages();
        
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddScoped<IFishWatersRepository, FishWaterDbContext>();

            services.AddEntityFrameworkNpgsql().AddDbContext<FishWaterDbContext>(opt =>
                    opt.UseNpgsql(Configuration.GetSection("ConnectionStrings")["FishWatersLocalConnection"]));
                    //options.UseNpgsql(Configuration.GetConnectionString("FishWatersLocalConnection")));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        });
        }


        private void MyRouting(IRouteBuilder routebuilder)
        {
            routebuilder.MapRoute("default", "{controller=FishWater}/{action=Index}/{id?}");
        }
    }
}
