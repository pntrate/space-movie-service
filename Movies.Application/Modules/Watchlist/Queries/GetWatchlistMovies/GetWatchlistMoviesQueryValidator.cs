using FluentValidation;

namespace Movies.Application.Modules.Watchlist.Queries.GetWatchlistMovies
{
    public class GetWatchlistMoviesQueryValidator : AbstractValidator<GetWatchlistMoviesQuery>
    {
        public GetWatchlistMoviesQueryValidator()
        {
            RuleFor(r => r.UserId).NotEmpty();
        }
    }
}