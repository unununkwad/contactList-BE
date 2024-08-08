using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using contactList_BE.Data;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//using contactList_BE.Service.Cron.DeleteUnnecessaryData;

namespace contactList_BE
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
			services.AddControllers();

			services.AddDbContext<DbCon>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Connection")));
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
		{
			app.UseCors("AllowOrigin");
			//app.UseCors();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

			}
			app.UseSwagger();



			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				//endpoints.MapHub<ConnectionHubs>("/hubs");
			});





			//if (env.IsDevelopment())
			//{
			//	app.UseDeveloperExceptionPage();
			//}
			//else
			//{
			//	app.UseExceptionHandler("/Home/Error");
			//	app.UseHsts();
			//}

			//app.UseHttpsRedirection();
			//app.UseStaticFiles();

			//app.UseRouting();

			//app.UseAuthorization();

			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapControllerRoute(
			//		name: "default",
			//		pattern: "{controller=Home}/{action=Index}/{id?}");
			//});

		}
	}
}
