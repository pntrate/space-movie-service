using MediatR;

namespace Movies.Application.Modules.Watchlist.Commands.AddMovieToWatchlist
{
    public class AddMovieToWatchlistCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public string ImdbMovieId { get; set; }
        public string? Image { get; set; }
        public string MovieTitle { get; set; }
        public string? Description { get; set; }
    }
}