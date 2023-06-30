using Movies.Domain.Common.Helpers;

namespace Movies.Domain.Entities
{
	public class WatchListMovie : Entity
	{
		public Guid WatchListId { get; private set; }
		public string ImdbMovieId { get; private set; }
		public string MovieTitle { get; private set; }
		public string Description { get; private set; }
		public bool IsWatched { get; private set; }
		public DateTime? WatchDate { get; private set; }
		public DateTime CreateDate { get; private set; }

		private WatchListMovie(Guid watchListId, string imdbMovieId, string movieTitle, string description) : base()
		{
			WatchListId = watchListId;
			ImdbMovieId = imdbMovieId;
			MovieTitle = movieTitle;
			Description = description;
			CreateDate = DateTimeProvider.Now;
		}

		public static WatchListMovie Create(Guid watchListId, string imdbMovieId, string movieTitle, string description)
		{
			return new WatchListMovie(watchListId, imdbMovieId, movieTitle, description);
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
