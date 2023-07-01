using MediatR;
using Microsoft.Extensions.Configuration;
using Movies.Application.Abstractions;
using Movies.Application.Common;
using Movies.Application.Common.Models;
using Movies.Domain.Common.Config;

namespace Movies.Application.Modules.Movie.Queries
{
	public class FetchMoviesFromImdbQueryHandler : ApplicationBase, IRequestHandler<FetchMoviesFromImdbQuery, IEnumerable<ImdbMovie>>
	{
		private readonly IImdbService _imdbService;
		private readonly IConfigurationRoot _configuration;

        public FetchMoviesFromImdbQueryHandler(IImdbService imdbService, IConfigurationRoot configuration) : base()
        {
			_imdbService = imdbService;
			_configuration = configuration;
		}

        public async Task<IEnumerable<ImdbMovie>> Handle(FetchMoviesFromImdbQuery request, CancellationToken cancellationToken)
		{
			var configuration = _configuration.GetSection(AppSettings.ImdbKey).Get<ImdbSettings>();
			var response = await _imdbService.SearchMovie(configuration.ApiKey, request.Expression);
			return response.Results;
		}
	}
}