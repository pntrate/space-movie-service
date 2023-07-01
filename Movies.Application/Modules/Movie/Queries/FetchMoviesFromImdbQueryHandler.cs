using MediatR;
using Microsoft.Extensions.Options;
using Movies.Application.Abstractions;
using Movies.Application.Common;
using Movies.Application.Common.Models;
using Movies.Domain.Common.Config;

namespace Movies.Application.Modules.Movie.Queries
{
	public class FetchMoviesFromImdbQueryHandler : ApplicationBase, IRequestHandler<FetchMoviesFromImdbQuery, IEnumerable<ImdbMovie>>
	{
		private readonly IImdbService _imdbService;
		private readonly IOptions<AppSettings> _appSettings;

        public FetchMoviesFromImdbQueryHandler(IImdbService imdbService, IOptions<AppSettings> appSettings) : base()
        {
			_imdbService = imdbService;
			_appSettings = appSettings;
		}

        public async Task<IEnumerable<ImdbMovie>> Handle(FetchMoviesFromImdbQuery request, CancellationToken cancellationToken)
		{
			var response = await _imdbService.SearchMovie(_appSettings.Value.ImdbSettings.ApiKey, request.Expression);
			return response.Results;
		}
	}
}