using Movies.Domain.Common.Contracts;

namespace Movies.Application.Common
{
	public class ApplicationBase
	{
        protected readonly IWatchlistRepository _watchlistRepository;

        public ApplicationBase()
        {
            
        }

        public ApplicationBase(IWatchlistRepository watchlistRepository)
        {
			_watchlistRepository = watchlistRepository;
		}
    }
}