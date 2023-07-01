using FluentValidation.AspNetCore;

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
            services.AddControllers();
            services.AddFluentValidationAutoValidation();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/index.html", "IMDB Movies API");
            });
        }

    }
}
