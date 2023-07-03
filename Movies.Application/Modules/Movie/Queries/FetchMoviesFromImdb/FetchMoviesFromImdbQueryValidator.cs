using FluentValidation;

namespace Movies.Application.Modules.Movie.Queries.FetchMoviesFromImdb
{
    public class FetchMoviesFromImdbQueryValidator : AbstractValidator<FetchMoviesFromImdbQuery>
    {
        public FetchMoviesFromImdbQueryValidator()
        {
            RuleFor(r => r.Expression).NotEmpty();
        }
    }
}