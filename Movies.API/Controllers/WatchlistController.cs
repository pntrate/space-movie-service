using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Modules.Watchlist.Commands.AddMovieToWatchlist;
using Movies.Application.Modules.Watchlist.Commands.MarkMovieAsWatched;
using Movies.Application.Modules.Watchlist.Queries.GetWatchlistMovies;
using Movies.Domain.Entities;

namespace Movies.API.Controllers
{
	[Route("watchlist")]
	public class WatchlistController : BaseApiController
	{
		[HttpPut("add-movie")]
		public async Task<Unit> SearchMovie([FromBody] AddMovieToWatchlistCommand request)
		{
			return await Mediator.Send(request);
		}

		[HttpGet("movies")]
		public async Task<Watchlist> SearchMovie([FromQuery] GetWatchlistMoviesQuery request)
		{
			return await Mediator.Send(request);
		}

		[HttpPost("mark-watched")]
		public async Task<Unit> MarkAsWatched([FromBody] MarkMovieAsWatchedCommand command)
		{
			return await Mediator.Send(command);
		}
	}
}
