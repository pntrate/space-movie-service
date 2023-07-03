using Movies.Domain.Common.Helpers;

namespace Movies.Domain.Entities
{
	public class Watchlist : Entity
    {
        public Guid UserId { get; private set; }
        public DateTime LastUpdateDate { get; private set; }

        public virtual List<WatchlistMovie> Movies { get; private set; }

        private Watchlist(Guid userId) : base()
        {
            UserId = userId;
            LastUpdateDate = DateTimeProvider.Now;
        }

        public static Watchlist Create(Guid userId)
        {
            return new Watchlist(userId);
        }

        public void AddMovie(string imdbMovieId, string image, string movieTitle, string description)
        {
            Movies.Add(WatchlistMovie.Create(Id, image, imdbMovieId, movieTitle, description));

            LastUpdateDate = DateTimeProvider.Now;
        }
    }
}