using Eduction.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.FrameWork.Infrastructure
{
    public class ControllerStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Low;

        public void Configure(IApplicationBuilder app)
        {
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }
	
	}
}
