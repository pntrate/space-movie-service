using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Movies.Persistence.Db
{
	public class WatchlistDbContextFactory : IDesignTimeDbContextFactory<WatchlistDbContext>
	{
		public WatchlistDbContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
														  .AddJsonFile("appsettings.json")
														  .Build();

			var connectionString = configuration.GetConnectionString("WatchlistDbConnection");
			var optionsBuilder = new DbContextOptionsBuilder<WatchlistDbContext>().UseSqlServer(connectionString);

			return new WatchlistDbContext(optionsBuilder.Options);
		}
	}
}