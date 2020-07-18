using Eduction.Core.Infrastructure;
using Eduction.FrameWork.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.FrameWork.Infrastructure
{
    public class CommonStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;

        public void Configure(IApplicationBuilder app)
        {
            IWebHostEnvironment env = app.ApplicationServices.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }
            app.UseMiddleware<Powerdby>();
        
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }
    }
}
