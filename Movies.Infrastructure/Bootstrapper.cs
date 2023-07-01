using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Movies.Application.Abstractions;
using Movies.Domain.Common.Config;
using Movies.Infrastructure.Services;

namespace Movies.Infrastructure
{
	public static class Bootstrapper
	{
		public static void AddInfrastructure(this IServiceCollection services, IConfigurationRoot configurationRoot)
		{
			services.AddTransient<IImdbService, ImdbService>();
			var imdbSettings = configurationRoot.GetSection(AppSettings.ImdbSettingsKey).Get<ImdbSettings>();
			services.AddHttpClient(ImdbService.CLIENT_NAME, httpClient =>
			{
				httpClient.BaseAddress = new Uri(imdbSettings.BaseUrl);
				httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
			});
		}
	}
}