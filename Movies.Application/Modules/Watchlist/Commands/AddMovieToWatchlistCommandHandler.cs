using MediatR;
using Movies.Application.Common;
using Movies.Domain.Common.Contracts;

namespace Movies.Application.Modules.Watchlist.Commands
{
	public class AddMovieToWatchlistCommandHandler : ApplicationBase, IRequestHandler<AddMovieToWatchlistCommand, Unit>
	{
		public AddMovieToWatchlistCommandHandler(IWatchlistRepository watchlistRepository) : base(watchlistRepository)
		{
		}

		public async Task<Unit> Handle(AddMovieToWatchlistCommand request, CancellationToken cancellationToken)
		{
			var watchlist = _watchlistRepository.FirstOrDefault(i => i.UserId == request.UserId, true, includes: i => i.Movies);
			if (watchlist is null)
			{
				watchlist = Domain.Entities.Watchlist.Create(request.UserId);
				watchlist.AddMovie(request.ImdbMovieId, request.Image, request.MovieTitle, request.Description);
				_watchlistRepository.Create(watchlist);
			}
			else
			{
				watchlist.AddMovie(request.ImdbMovieId, request.Image, request.MovieTitle, request.Description);
				_watchlistRepository.Update(watchlist);
			}

			await _watchlistRepository.Save();

			return Unit.Value;
		}
	}
}