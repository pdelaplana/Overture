using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;
using MongoDB.Driver;

namespace Overture.Infrastructure.Persistance.MongoDB
{
	public class BusinessServiceRepository : MongoRepository<BusinessService>, IBusinessServiceRepository
	{
		
		public BusinessServiceRepository(MongoDBContext context):base(context, "business_services")
		{
			
		}

		/*
		public BusinessService Add(BusinessService entity)
		{
			_collection.InsertOne(entity);
			return entity;
		}

		public void Add(IEnumerable<BusinessService> entities)
		{
			_collection.InsertMany(entities);
		}

		public async Task<BusinessService> AddAsync(BusinessService entity)
		{
			await _collection.InsertOneAsync(entity);
			return entity;
		}

		public async Task AddAsync(IEnumerable<BusinessService> entities)
		{
			await _collection.InsertManyAsync(entities);
		}

		public BusinessService Udpate(BusinessService entity)
		{
			FilterDefinition<BusinessService> filter = Builders<BusinessService>.Filter.Eq("Id", entity.Id);
			if (_collection.ReplaceOne(filter, entity).ModifiedCount > 0)
			{
				return entity;
			}
			else
			{
				return null;
			}
		}

		public async Task<BusinessService> UpdateAsync(BusinessService entity)
		{
			FilterDefinition<BusinessService> filter = Builders<BusinessService>.Filter.Eq("Id", entity.Id);
			var result = await _collection.ReplaceOneAsync(filter, entity);
			if (result.ModifiedCount > 0)
			{
				return entity;
			}
			else
			{
				return null;
			}
		}


		public IQueryable<BusinessService> All()
		{
			return _collection.AsQueryable();

		}

		public void Delete(Expression<Func<BusinessService, bool>> expression)
		{
		
			throw new NotImplementedException();
		}

		public bool Delete(BusinessService entity)
		{
			FilterDefinition<BusinessService> filter = Builders<BusinessService>.Filter.Eq("Id", entity.Id);
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

		public Task DeleteAsync(Expression<Func<BusinessService, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> DeleteAsync(BusinessService entity)
		{
			FilterDefinition<BusinessService> filter = Builders<BusinessService>.Filter.Eq("Id", entity.Id);
			return ((await _collection.DeleteOneAsync(filter)).DeletedCount>0);
		}

		public void Dispose()
		{
			// do dispose
			
		}

		public BusinessService Single(Expression<Func<BusinessService, bool>> expression)
		{
			throw new NotImplementedException();
		}

		public Task<BusinessService> SingleAsync(Expression<Func<BusinessService, bool>> expression)
		{
			throw new NotImplementedException();
		}
		*/
	
	}
}
