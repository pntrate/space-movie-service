using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Persistence.Db.Mapping;

namespace Movies.Persistence.Db
{
	public class WatchlistDbContext : DbContext
	{
		public DbSet<Watchlist> Watchlists { get; set; }
		public DbSet<WatchlistMovie> WatchlistMovies { get; set; }

        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("movie");

			modelBuilder.Entity<Watchlist>(new WatchlistMap().Configure);
			modelBuilder.Entity<WatchlistMovie>(new WatchlistMovieMap().Configure);
		}
	}
}