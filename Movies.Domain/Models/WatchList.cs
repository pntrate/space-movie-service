using Movies.Domain.Common.Enums;
using Movies.Domain.Common.Helpers;

namespace Movies.Domain.Models
{
	public class WatchList : Entity
	{
		public Guid UserId { get; private set; }
		public DateTime LastUpdateDate { get; private set; }

		public virtual List<WatchListMovie> Movies { get; private set; }

        private WatchList(Guid userId, DateTime lastUpdateDate) : base()
        {
			UserId = userId;
			LastUpdateDate = lastUpdateDate;
		}

        public static WatchList Create(Guid userId, DateTime lastUpdateDate)
		{
			return new WatchList(userId, lastUpdateDate);
		}

		public void AddMovie(string imdbMovieId, MovieType movieType, string movieTitle, string description)
		{
			Movies.Add(WatchListMovie.Create(Id, imdbMovieId, movieType, movieTitle, description));

			LastUpdateDate = DateTimeProvider.Now;
		}
	}
}
