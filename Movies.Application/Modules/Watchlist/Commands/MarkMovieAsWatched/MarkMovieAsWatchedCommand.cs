using MediatR;

namespace Movies.Application.Modules.Watchlist.Commands.MarkMovieAsWatched
{
	public class MarkMovieAsWatchedCommand : IRequest<Unit>
	{
		public Guid WatchlistMovieId { get; set; }
	}
}