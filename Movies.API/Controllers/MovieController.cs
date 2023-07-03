using Microsoft.AspNetCore.Mvc;
using Movies.Application.Common.Models;
using Movies.Application.Modules.Movie.Queries.FetchMoviesFromImdb;

namespace Movies.API.Controllers
{
    [Route("movie")]
	public class MovieController : BaseApiController
	{
		[HttpGet("search")]
		public async Task<IEnumerable<ImdbMovie>> SearchMovie([FromQuery] FetchMoviesFromImdbQuery request)
		{
			return await Mediator.Send(request);
		}

	}
}
