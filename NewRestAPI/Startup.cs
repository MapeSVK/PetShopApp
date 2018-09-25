using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationService;
using Core.ApplicationService.Implementations;
using Core.DomainService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Implementations;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Database;

namespace NewRestAPI
{
	public class Startup
	{
		/*public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			
		} */
		private IConfiguration _conf { get; }

		private IHostingEnvironment _env { get; set; }

		public Startup(IHostingEnvironment env)
		{
			_env = env;
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			_conf = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{



			if (_env.IsDevelopment())
			{
				services.AddDbContext<PetShopAppContext>(
					opt => opt.UseSqlite("Data Source=Data.db")
				);
			}

			else if (_env.IsProduction())
			{
				services.AddDbContext<PetShopAppContext>(
					opt => opt.UseSqlServer(_conf.GetConnectionString("DefaultConnection")));
			}
			
			services.AddScoped<IPetRepository, PetRepository>();
			services.AddScoped<IOwnerRepository, OwnerRepository>();
			services.AddScoped<IPetService, PetService>();
			services.AddScoped<IOwnerService, OwnerService>();

			services.AddMvc().AddJsonOptions(options => {
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			});
			
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				using (var scope = app.ApplicationServices.CreateScope())
				{
					var ctx = scope.ServiceProvider.GetService<PetShopAppContext>();
					DBInitializer.SeedDB(ctx);
				}
			}
			else
			{
				using (var scope = app.ApplicationServices.CreateScope())
				{
					var ctx = scope.ServiceProvider.GetService<PetShopAppContext>();
					ctx.Database.EnsureCreated();
				}
				app.UseHsts();
			}

			//app.UseHttpsRedirection();
			app.UseMvc();
		}
	}

}
