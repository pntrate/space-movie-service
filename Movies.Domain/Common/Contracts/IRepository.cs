using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Movies.Domain.Common.Contracts
{
	public interface IRepository<TEntity> : IDisposable
	{
		IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>>? @where = null, bool tracking = false, Expression<Func<TEntity, object>>[]? includes = null);
		Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? @where = null, bool tracking = false, params Expression<Func<TEntity, object>>[]? includes);
		void Create(TEntity entity);
		void Update(TEntity entity);
		Task<int> Save();
	}
}