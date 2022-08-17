using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCDb
{
	public class Startup
	{
		IConfiguration config;
		public Startup(IConfiguration configuration)
		{
			 config = configuration ;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DB1045Context>(db => db.UseSqlServer(config.GetConnectionString("mycon")));
			services.AddMvc(ep => ep.EnableEndpointRouting = false);
			services.AddTransient<IDept, DeptRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseRouting();
			app.UseMvc(routes => {

				routes.MapRoute(
					name:"default",
					template:"{controller=Dept}/{action=List}/{id?}"
					);
			});
			

		}
	}
}
