using Eduction.Core.Extension;
using Eduction.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.FrameWork.Infrastructure.Extension
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
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
                item.Configure(application);
            }
        }
    }
}
