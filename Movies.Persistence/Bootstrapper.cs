﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Common.Contracts;
using Movies.Persistence.Db;
using Movies.Persistence.Repositories;

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

			services.AddScoped<IWatchlistRepository, WatchlistRepository>();
			services.AddScoped<IWatchlistMovieRepository, WatchlistMovieRepository>();

			var sp = services.BuildServiceProvider();
			var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
			using var scope = scopeFactory.CreateScope();
			using var context = sp.GetService(typeof(WatchlistDbContext)) as WatchlistDbContext;
			context?.Database.Migrate();
		}
	}
}