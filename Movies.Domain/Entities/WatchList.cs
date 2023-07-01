using Movies.Domain.Common.Helpers;

namespace Movies.Domain.Entities
{
	public class Watchlist : Entity
    {
        public Guid UserId { get; private set; }
        public DateTime LastUpdateDate { get; private set; }

        public virtual List<WatchlistMovie> Movies { get; private set; }

        private Watchlist(Guid userId, DateTime lastUpdateDate) : base()
        {
            UserId = userId;
            LastUpdateDate = lastUpdateDate;
        }

        public static Watchlist Create(Guid userId, DateTime lastUpdateDate)
        {
            return new Watchlist(userId, lastUpdateDate);
        }

        public void AddMovie(string imdbMovieId, string movieTitle, string description)
        {
            Movies.Add(WatchlistMovie.Create(Id, imdbMovieId, movieTitle, description));

            LastUpdateDate = DateTimeProvider.Now;
        }
    }
}
