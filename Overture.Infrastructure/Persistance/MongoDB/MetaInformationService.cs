using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Overture.Core.Application;
using Overture.Core.Domain.ValueObjects;
using Overture.Core.Services;

namespace Overture.Infrastructure.Persistance.MongoDB
{
	public class MetaInformationService : IMetaInformationService
	{
		private readonly MongoDBContext _context;
		private readonly IMongoCollection<MetaInformation> _collection;

		public MetaInformationService(MongoDBContext context)
		{
			_context = context;
			_collection = _context.Database.GetCollection<MetaInformation>("meta_information");
		}

		public IEnumerable<ServiceArea> ServiceAreas
		{
			get => _collection.AsQueryable().FirstOrDefault()?.ServiceAreas;
		}

		public MetaInformation Current
		{
			get => _collection.AsQueryable().FirstOrDefault();
			set
			{
				var meta = _collection.AsQueryable().FirstOrDefault();
				if (meta == null)
				{
					_collection.InsertOne(value);
				}
				else
				{
					meta.ServiceAreas = value.ServiceAreas;
					meta.ContactMethodTypes = value.ContactMethodTypes;
					meta.ServiceCategories = value.ServiceCategories;
					var filter = Builders<MetaInformation>.Filter.Eq("Id", meta.Id);
					_collection.ReplaceOne(filter, meta);
				}
			}
		}
	}
}
