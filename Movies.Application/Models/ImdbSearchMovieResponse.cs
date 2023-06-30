namespace Movies.Application.Models
{
	public class ImdbSearchMovieResponse
	{
		public string SearchType { get; set; }	
		public string Expression { get; set; }
		public List<ImdbMovie> Results { get; set; }
		public string ErrorMessage { get; set; }
	}
}