using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using museum_backend.Services;
using museum_backend.Setting;

namespace museum_backend
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
			services.Configure<DBSettings>(
				Configuration.GetSection(nameof(DBSettings)));

			services.AddSingleton<IDBSettings>(sp =>
				sp.GetRequiredService<IOptions<DBSettings>>().Value);

			services.Configure<ImageSettings>(
				Configuration.GetSection(nameof(ImageSettings)));

			services.AddSingleton<IImageSettings>(sp =>
				sp.GetRequiredService<IOptions<ImageSettings>>().Value);

			services.AddSingleton<AnimalService>();
			services.AddSingleton<DonerService>();
			services.AddSingleton<NewsService>();
			services.AddSingleton<OrganService>();
			services.AddSingleton<TaxonomyService>();
			services.AddSingleton<ImageService>();

			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
				builder =>
				{
					builder
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
				});
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors("AllowAll");

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			
		}
	}
}
