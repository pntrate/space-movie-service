using FluentValidation;

namespace Movies.Application.Modules.Watchlist.Commands
{
	public class AddMovieToWatchlistCommandValidator : AbstractValidator<AddMovieToWatchlistCommand>
	{
        public AddMovieToWatchlistCommandValidator()
        {
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.ImdbMovieId).NotEmpty();
            RuleFor(r => r.MovieTitle).NotEmpty();
        }
    }
}