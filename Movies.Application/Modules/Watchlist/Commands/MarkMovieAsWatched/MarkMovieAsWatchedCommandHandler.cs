using MediatR;
using Movies.Domain.Common.Contracts;

namespace Movies.Application.Modules.Watchlist.Commands.MarkMovieAsWatched
{
	public class MarkMovieAsWatchedCommandHandler : IRequestHandler<MarkMovieAsWatchedCommand, Unit>
	{
		private readonly IWatchlistMovieRepository _watchlistMovieRepository;

        public MarkMovieAsWatchedCommandHandler(IWatchlistMovieRepository watchlistMovieRepository)
		{
			_watchlistMovieRepository = watchlistMovieRepository;
		}

		public async Task<Unit> Handle(MarkMovieAsWatchedCommand command, CancellationToken cancellationToken)
		{
			var watchlistMovie = await _watchlistMovieRepository.FirstOrDefaultAsync(i => i.Id == command.WatchlistMovieId, true)
								?? throw new Exception("Watchlist movie not found");

			watchlistMovie.MarkAsWatched();

			_watchlistMovieRepository.Update(watchlistMovie);
			await _watchlistMovieRepository.Save();

			return Unit.Value;
		}
	}
}