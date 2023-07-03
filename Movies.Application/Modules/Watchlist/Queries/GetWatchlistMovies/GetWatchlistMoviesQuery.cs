using MediatR;

namespace Movies.Application.Modules.Watchlist.Queries.GetWatchlistMovies
{
    public class GetWatchlistMoviesQuery : IRequest<Domain.Entities.Watchlist>
    {
        public Guid UserId { get; set; }
    }
}
