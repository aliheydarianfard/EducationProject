using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduction.Core.Domains;
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
using Microsoft.AspNetCore.Identity;
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
			services.AddMvc(option => option.EnableEndpointRouting = false);
			DIMethod(services);
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

			services.AddDbContext<SqlServerApplicationContext>();
			services.AddIdentity<Customer, CustomerRole>().AddEntityFrameworkStores<SqlServerApplicationContext>().AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityErrorDescriber>();
			services.Configure<IdentityOptions>(options =>
			{
				// Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;

				// Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
				options.Lockout.MaxFailedAccessAttempts = 2;
				options.Lockout.AllowedForNewUsers = true;

				// User settings.
				options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = false;
			});

			services.ConfigureApplicationCookie(options =>
			{
				// Cookie settings
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

				options.LoginPath = "/Admin/Account/Login";
				options.AccessDeniedPath = "/Admin/Account/AccessDenied";
				options.LogoutPath = "/Admin/Account/Logout";
				options.SlidingExpiration = true;
			});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		private static void DIMethod(IServiceCollection services)
		{
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ITeacherService, TeacherService>();
			services.AddScoped<IHomeService, HomeService>();
			services.AddScoped<ICourseService, CourseService>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/error");
				app.UseHsts();
			}
			app.UseStatusCodePagesWithReExecute("/Error/GeneralError","?statusCode={0}");
			app.UseHttpsRedirection(); 
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseAuthentication();
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
			app.UseMvc(route =>
			{
				route.MapRoute("GeneralError", "error", new { controller = "Error", action = "GeneralError" });
			});
			app.UseMvc(route =>
			{
				route.MapRoute("generalerror", "Lockout", new { controller = "Error", action = "Lockout" });
			});

		}
	}
	public class CustomIdentityErrorDescriber : IdentityErrorDescriber
	{
		public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"An unknown failure has occurred." }; }
		public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Optimistic concurrency failure, object has been modified." }; }
		public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "Incorrect password." }; }
		public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "Invalid token." }; }
		public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "A user with this login already exists." }; }
		public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"User name '{userName}' is invalid, can only contain letters or digits." }; }
		public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"Email '{email}' is invalid." }; }
		public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"User Name '{userName}' is already taken." }; }
		public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"Email '{email}' is already taken." }; }
		public override IdentityError InvalidRoleName(string role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = $"Role name '{role}' is invalid." }; }
		public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"Role name '{role}' is already taken." }; }
		public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "User already has a password set." }; }
		public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "Lockout is not enabled for this user." }; }
		public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"کار در نقش  '{role}'. وجود دارد" }; }
		public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description = $"کاربر در نقش '{role}' نیست." }; }
		public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"رمز عبور باید حداقل طول {length} را داشته باشد." }; }
		public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "رمز عبور باید حداقل شامل یک کاراکتر غیر حرف و عدد باشد" }; }
		public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "رمز عبور باید اعداد بین 0 تا 9 را داشته باشد ')." }; }
		public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "رمز عبور باید حروف کوچک بین a تا z را داشته باشد" }; }
		public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "رمز عبور باید حروف بزرگ بین A تا Z را داشته باشد" }; }
	}
}
