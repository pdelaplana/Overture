using System;
using System.Collections.Generic;
using System.Text;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;

namespace Overture.Infrastructure.Persistance.MongoDB
{
    public class JobRepository : MongoRepository<Job>, IJobRepository
    {
		public JobRepository(MongoDBContext context) : base(context, "jobs")
		{
		}
	}
}
