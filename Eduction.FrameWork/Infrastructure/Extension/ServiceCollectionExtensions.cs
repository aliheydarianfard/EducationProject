
using Eduction.Core.Extension;
using Eduction.Core.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.FrameWork.Infrastructure.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var ListTypes = typeof(IApplicationStartup).GetAllClassTypes();

            List<IApplicationStartup> ListObjects = new List<IApplicationStartup>();

            foreach (var Typeitem in ListTypes)
            {
                var ob = Activator.CreateInstance(Typeitem) as IApplicationStartup;
                ListObjects.Add(ob);
            }

            foreach (var item in ListObjects)
            {
                item.ConfigureServices(services, configuration);
            }
        }
    }
}
