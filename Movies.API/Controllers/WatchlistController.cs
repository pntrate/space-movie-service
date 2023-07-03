using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Modules.Watchlist.Commands;

namespace Movies.API.Controllers
{
	[Route("watchlist")]
	public class WatchlistController : BaseApiController
	{
		[HttpPost("add-movie")]
		public async Task<Unit> SearchMovie([FromBody] AddMovieToWatchlistCommand request)
		{
			return await Mediator.Send(request);
		}

	}
}
