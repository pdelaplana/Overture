using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Text;
using Overture.Core.Domain.Entities;

namespace Overture.Core.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity:IEntity
    {
		TEntity Single(Expression<Func<TEntity, bool>> expression);
		Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression);
		IQueryable<TEntity> All();
		TEntity Add(TEntity entity);
		Task<TEntity> AddAsync(TEntity entity);
		void Add(IEnumerable<TEntity> entities);
		Task AddAsync(IEnumerable<TEntity> entities);
		TEntity Udpate(TEntity entity);
		Task<TEntity> UpdateAsync(TEntity entity);
		void Delete(Expression<Func<TEntity, bool>> expression);
		Task DeleteAsync(Expression<Func<TEntity, bool>> expression);
		bool Delete(TEntity entity);
		Task<bool> DeleteAsync(TEntity entity);
		void DeleteAll();
		Task DeleteAllAsync();
	}
}
