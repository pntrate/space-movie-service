using FluentValidation;

namespace Movies.Application.Modules.Watchlist.Commands.MarkMovieAsWatched
{
	public class MarkMovieAsWatchedCommandValidator : AbstractValidator<MarkMovieAsWatchedCommand>
	{
        public MarkMovieAsWatchedCommandValidator()
        {
			RuleFor(r => r.WatchlistMovieId).NotEmpty();
		}
	}
}