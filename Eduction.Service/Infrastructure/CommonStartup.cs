using Eduction.Core.Infrastructure;
using Eduction.Service.Catalog.Category;
using Eduction.Service.Catalog.Course;
using Eduction.Service.Catalog.Home;
using Eduction.Service.Catalog.Teacher;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Service.Infrastructure
{
    public class CommonStartup : IApplicationStartup
    {
        public MiddleWarePriority Priority => MiddleWarePriority.Normal;

        public void Configure(IApplicationBuilder app)
        {
        
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ICourseService, CourseService>();
        }
    }
}
