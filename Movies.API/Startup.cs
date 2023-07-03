using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Movies.Application;
using Movies.Domain.Common.Config;
using Movies.Infrastructure;

namespace Movies.API
{
	public sealed class Startup
	{
		public IConfigurationRoot Configuration { get; set; }
		public IWebHostEnvironment Environment { get; set; }

		public Startup(IConfigurationRoot configurationRoot, IWebHostEnvironment environment)
		{
			Configuration = configurationRoot;
			Environment = environment;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<AppSettings>(Configuration);

			services.AddControllers();
			services.AddFluentValidationAutoValidation();

			services.AddAplicationLayer();
			services.AddInfrastructure(Configuration);

			services.AddEndpointsApiExplorer();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Imdb Movie API",
					Description = "List of endpoints"
				});
			});
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMDB.Movies.API");
			});

			app.UseRouting();
			app.UseHttpsRedirection();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers().AllowAnonymous();
			});
		}

	}
}
