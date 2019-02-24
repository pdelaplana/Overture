using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Overture.Core.Repositories;

namespace Overture.Infrastructure.Persistance.MongoDB
{
    public class MongoDBContext
    {
		public MongoDBContext(IOptions<RepositorySettings> options)
		{
			var client = new MongoClient(options.Value.ConnectionString);
			Database = client.GetDatabase(options.Value.Database);
		}
		
		public IMongoDatabase Database { get; }
	}
}
