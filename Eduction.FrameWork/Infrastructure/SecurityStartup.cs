using Eduction.Core.Domains;
using Eduction.Core.Infrastructure;
using Eduction.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.FrameWork.Infrastructure
{
    public class SecurityStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.High;

        public void Configure(IApplicationBuilder app)
        {
           
            app.UseHttpsRedirection();
            
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
			
		}
		
	}
}
