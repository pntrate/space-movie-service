using Movies.Domain.Common.Contracts;
using Movies.Domain.Entities;
using Movies.Persistence.Db;

namespace Movies.Persistence.Repositories
{
	public class WatchlistRepository : Repository<Watchlist>, IWatchlistRepository
	{
		public WatchlistRepository(WatchlistDbContext context) : base(context)
		{

		}
		
	}
}