using Microsoft.EntityFrameworkCore;
using Movies.Domain.Common.Contracts;
using Movies.Persistence.Db;
using System.Linq.Expressions;

namespace Movies.Persistence
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly WatchlistDbContext _context;

		protected Repository(WatchlistDbContext context)
		{
			_context = context;
		}

		public virtual void Dispose()
		{
			_context.Dispose();
		}

		public IQueryable<TEntity> Queryable(
			Expression<Func<TEntity, bool>>? @where = null,
			bool tracking = false,
			Expression<Func<TEntity, object>>[]? includes = null)
		{
			var queryable = _context.Set<TEntity>().AsQueryable();

			if (where != null)
			{
				queryable = queryable.Where(where);
			}

			if (includes != null)
			{
				foreach (var includeExpression in includes)
				{
					queryable = queryable.Include(includeExpression);
				}
			}

			return tracking ? queryable : queryable.AsNoTracking();
		}

		public async Task<TEntity?> FirstOrDefaultAsync(
			Expression<Func<TEntity, bool>>? @where = null,
			bool tracking = false,
			params Expression<Func<TEntity, object>>[]? includes)
		{
			var queryable = Queryable(@where, tracking, includes);
			return await queryable.FirstOrDefaultAsync();
		}

		public void Create(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			_context.Set<TEntity>().Add(entity);
		}

		public void Update(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			_context.Set<TEntity>().Update(entity);
		}

		public Task<int> Save()
		{
			return _context.SaveChangesAsync();
		}
	}
}