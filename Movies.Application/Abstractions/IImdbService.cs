using Movies.Application.Common.Models;

namespace Movies.Application.Abstractions
{
    public interface IImdbService
	{
		Task<ImdbSearchMovieResponse> SearchMovie(string apiKey, string expression);
	}
}