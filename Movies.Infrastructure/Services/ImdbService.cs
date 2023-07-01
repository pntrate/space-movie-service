using Movies.Application.Abstractions;
using Movies.Application.Common.Models;
using System.Text.Json;

namespace Movies.Infrastructure.Services
{
	public class ImdbService : IImdbService
	{
		private const string CLIENT_NAME = "ImdbApi";

		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;

		public ImdbService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient(CLIENT_NAME);
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};
		}

		public async Task<ImdbSearchMovieResponse> SearchMovie(string apiKey, string expression)
		{
			const string methodName = "SearchMovie";

			var httpResponseMessage = await _httpClient.GetAsync($"{methodName}/{apiKey}/{expression}");
			if (!httpResponseMessage.IsSuccessStatusCode)
			{
				throw new Exception($"{nameof(ImdbService)} Request Unsuccessful, Statuscode: {httpResponseMessage.StatusCode}, ReasonPhrase {httpResponseMessage.ReasonPhrase}");
			}

			var responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
			var imdbSearchMovieResponse = JsonSerializer.Deserialize<ImdbSearchMovieResponse>(responseJson) 
										  ?? throw new Exception($"{nameof(ImdbService)} Couldn't Deserialize Result");

			return imdbSearchMovieResponse;
		}
	}
}