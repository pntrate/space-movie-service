namespace Movies.Domain.Common.Config
{
	public class AppSettings
	{
		public static readonly string ConnectionStringsKey = "ConnectionStrings";
		public static readonly string ImdbKey = "Imdb";

		public ConnectionStrings ConnectionStrings { get; set; }
		public ImdbSettings ImdbSettings { get; set; }
	}

	public class ConnectionStrings
	{
		public string MoviesDbConnection { get; set; }
	}

	public class ImdbSettings
	{
		public string BaseUrl { get; set; }
		public string ApiKey { get; set; }
	}
}