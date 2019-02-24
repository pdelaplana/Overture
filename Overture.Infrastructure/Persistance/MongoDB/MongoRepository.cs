using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;

namespace Overture.Infrastructure.Persistance.MongoDB
{
	public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
	{
		private readonly MongoDBContext _context;
		private readonly IMongoCollection<TEntity> _collection;

		public MongoRepository(MongoDBContext context, string collectionName)
		{
			_context = context;
			_collection = _context.Database.GetCollection<TEntity>(collectionName);
		}

		public TEntity Add(TEntity entity)
		{
			_collection.InsertOne(entity);
			return entity;
		}

		public void Add(IEnumerable<TEntity> entities)
		{
			_collection.InsertMany(entities);
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			await _collection.InsertOneAsync(entity);
			return entity;
		}

		public async Task AddAsync(IEnumerable<TEntity> entities)
		{
			await _collection.InsertManyAsync(entities);
		}

		public IQueryable<TEntity> All()
		{
			return _collection.AsQueryable();
		}

		public void Delete(Expression<Func<TEntity, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public bool Delete(TEntity entity)
		{
			FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
			return (_collection.DeleteOne(filter).DeletedCount > 0);
		}

		public void DeleteAll()
		{
			throw new NotImplementedException();
		}

		public Task DeleteAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Expression<Func<TEntity, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> DeleteAsync(TEntity entity)
		{
			FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
			return ((await _collection.DeleteOneAsync(filter)).DeletedCount > 0);
		}

		public void Dispose()
		{
			
		}

		public TEntity Single(Expression<Func<TEntity, bool>> expression)
		{
			
			throw new NotImplementedException();
		}

		public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public TEntity Udpate(TEntity entity)
		{
			FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
			if (_collection.ReplaceOne(filter, entity).ModifiedCount > 0)
			{
				return entity;
			}
			else
			{
				return default(TEntity);
			}
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
			var result = await _collection.ReplaceOneAsync(filter, entity);
			if (result.ModifiedCount > 0)
			{
				return entity;
			}
			else
			{
				return default(TEntity);
			}
		}
	}
}
