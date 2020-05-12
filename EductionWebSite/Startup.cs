using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduction.Data;
using Eduction.Data.Repository;
using Eduction.Service.Catalog.Category;
using Eduction.Service.Catalog.Course;
using Eduction.Service.Catalog.Home;
using Eduction.Service.Catalog.Teacher;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EductionWeb
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
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ITeacherService, TeacherService>();
			services.AddScoped<IHomeService, HomeService>();
			services.AddScoped<ICourseService, CourseService>();
			services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
			services.AddDbContextPool<IApplcationDbContext, SqlServerApplicationContext>(
			 c => c.UseSqlServer("Data Source=.;Initial Catalog=EductionDB;Integrated Security=true;")
		 , poolSize: 16);
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
			app.UseCookiePolicy();

			app.UseMvc(route =>
			{
				route.MapRoute("Default", "{controller}/{action}/{id?}", new { controller = "Home", action = "Index" });
			});
			app.UseMvc(route =>
			{
				route.MapRoute("AreaDefault", "{area}/{controller}/{action}/{id?}", new { area = "Admin", controller = "Home", action = "Index" });
			});
			app.UseMvc(route =>
			{
				route.MapRoute("home", "home", new { controller = "Home", action = "Index" });
			});
		}
	}
}
