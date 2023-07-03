using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Persistence.Db;

namespace Movies.Persistence
{
	public static class Bootstrapper
	{
		public static void AddDataInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
		{
			services.AddDbContext<WatchlistDbContext>((sp, dbContextOptions) =>
			{
				dbContextOptions.UseSqlServer(configuration.GetConnectionString("WatchlistDbConnection"));
			});
		}
	}
}