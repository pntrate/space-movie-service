using MediatR;
using Movies.Domain.Common.Contracts;

namespace Movies.Application.Modules.Watchlist.Commands.AddMovieToWatchlist
{
	public class AddMovieToWatchlistCommandHandler : IRequestHandler<AddMovieToWatchlistCommand, Unit>
    {
        private readonly IWatchlistRepository _watchlistRepository;

        public AddMovieToWatchlistCommandHandler(IWatchlistRepository watchlistRepository)
        {
			_watchlistRepository = watchlistRepository;

		}

        public async Task<Unit> Handle(AddMovieToWatchlistCommand command, CancellationToken cancellationToken)
        {
            var watchlist = await _watchlistRepository.FirstOrDefaultAsync(i => i.UserId == command.UserId, true, includes: i => i.Movies);
            if (watchlist is null)
            {
                watchlist = Domain.Entities.Watchlist.Create(command.UserId);
                watchlist.AddMovie(command.ImdbMovieId, command.Image, command.MovieTitle, command.Description);
                _watchlistRepository.Create(watchlist);
            }
            else
            {
                watchlist.AddMovie(command.ImdbMovieId, command.Image, command.MovieTitle, command.Description);
                _watchlistRepository.Update(watchlist);
            }

            await _watchlistRepository.Save();

            return Unit.Value;
        }
    }
}