namespace Movies.Domain.Common.Config
{
	public class AppSettings
	{
		public static readonly string ConnectionStringsKey = "ConnectionStrings";
		public static readonly string ImdbSettingsKey = "ImdbSettings";

		public ConnectionStrings ConnectionStrings { get; set; }
		public ImdbSettings ImdbSettings { get; set; }
	}

	public class ConnectionStrings
	{
		public string WatchlistDbConnection { get; set; }
	}

	public class ImdbSettings
	{
		public string BaseUrl { get; set; }
		public string ApiKey { get; set; }
	}
}