using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Movies.Application;
using Movies.Application.Abstractions;
using Movies.Domain.Common.Config;
using Movies.Infrastructure;
using Movies.Infrastructure.Services;

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

			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			});

			app.UseRouting();
			app.UseHttpsRedirection();
			app.UseCors();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers().AllowAnonymous();
			});
		}

	}
}
