using Movies.Domain.Common.Helpers;

namespace Movies.Domain.Entities
{
	public class Watchlist : Entity
    {
        public Guid UserId { get; private set; }
        public DateTime LastUpdateDate { get; private set; }

        public virtual List<WatchlistMovie> Movies { get; set; }

        private Watchlist()
        {
			
		}

        private Watchlist(Guid userId) : base()
        {
            UserId = userId;
            LastUpdateDate = DateTimeProvider.Now;
			Movies = new List<WatchlistMovie>();
		}

        public static Watchlist Create(Guid userId)
        {
            return new Watchlist(userId);
        }

        public void AddMovie(string imdbMovieId, string? image, string movieTitle, string? description)
        {
            Movies.Add(WatchlistMovie.Create(Id, imdbMovieId, image, movieTitle, description));

            LastUpdateDate = DateTimeProvider.Now;
        }
    }
}