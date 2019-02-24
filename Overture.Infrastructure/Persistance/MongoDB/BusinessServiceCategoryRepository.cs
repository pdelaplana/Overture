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
	public class BusinessServiceCategoryRepository :   MongoRepository<BusinessServiceCategory>, IBusinessServiceCategoryRepository 
	{
		
		public BusinessServiceCategoryRepository(MongoDBContext context):base(context, "service_categories")
		{

		}

		
	}
}
