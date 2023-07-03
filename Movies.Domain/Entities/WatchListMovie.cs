using Movies.Domain.Common.Helpers;

namespace Movies.Domain.Entities
{
	public class WatchlistMovie : Entity
	{
		public Guid WatchlistId { get; private set; }
		public string ImdbMovieId { get; private set; }
		public string Image { get; private set; }
		public string MovieTitle { get; private set; }
		public string Description { get; private set; }
		public bool IsWatched { get; private set; }
		public DateTime? WatchDate { get; private set; }
		public DateTime CreateDate { get; private set; }

		private WatchlistMovie(Guid watchlistId, string imdbMovieId, string image, string movieTitle, string description) : base()
		{
			WatchlistId = watchlistId;
			ImdbMovieId = imdbMovieId;
			Image = image;
			MovieTitle = movieTitle;
			Description = description;
			CreateDate = DateTimeProvider.Now;
		}

		public static WatchlistMovie Create(Guid watchlistId, string imdbMovieId, string image, string movieTitle, string description)
		{
			return new WatchlistMovie(watchlistId, imdbMovieId, image, movieTitle, description);
		}

		public void MarkAsWatched()
		{
			if (IsWatched)
			{
				throw new Exception("Movie has already been watched!");
			}
			IsWatched = true;
			WatchDate = DateTimeProvider.Now;
		}
	}
}
