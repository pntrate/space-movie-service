using MediatR;
using Movies.Application.Common.Models;

namespace Movies.Application.Modules.Movie.Queries.FetchMoviesFromImdb
{
    public class FetchMoviesFromImdbQuery : IRequest<IEnumerable<ImdbMovie>>
    {
        public string Expression { get; set; }
    }
}