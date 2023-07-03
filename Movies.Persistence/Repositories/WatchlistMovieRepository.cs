using Movies.Domain.Common.Contracts;
using Movies.Domain.Entities;
using Movies.Persistence.Db;

namespace Movies.Persistence.Repositories
{
	public class WatchlistMovieRepository : Repository<WatchlistMovie>, IWatchlistMovieRepository
	{
		public WatchlistMovieRepository(WatchlistDbContext context) : base(context)
		{

		}
	}
}