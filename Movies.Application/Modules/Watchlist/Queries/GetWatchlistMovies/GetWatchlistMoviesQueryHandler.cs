using MediatR;
using Movies.Domain.Common.Contracts;

namespace Movies.Application.Modules.Watchlist.Queries.GetWatchlistMovies
{
	public class GetWatchlistMoviesQueryHandler : IRequestHandler<GetWatchlistMoviesQuery, Domain.Entities.Watchlist>
    {
		private readonly IWatchlistRepository _watchlistRepository;

		public GetWatchlistMoviesQueryHandler(IWatchlistRepository watchlistRepository)
        {
            _watchlistRepository = watchlistRepository;
		}

        public async Task<Domain.Entities.Watchlist> Handle(GetWatchlistMoviesQuery request, CancellationToken cancellationToken)
        {
            var watchlist = await _watchlistRepository.FirstOrDefaultAsync(i => i.UserId == request.UserId, true, includes: i => i.Movies)
                            ?? throw new Exception("User has no watchlist");

            return watchlist;
        }
    }
}