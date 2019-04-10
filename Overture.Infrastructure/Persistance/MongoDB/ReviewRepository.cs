using System;
using System.Collections.Generic;
using System.Text;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;

namespace Overture.Infrastructure.Persistance.MongoDB
{
	public class ReviewRepository : MongoRepository<Review>, IReviewRepository
	{
		public ReviewRepository(MongoDBContext context) : base(context, "reviews")
		{
		}
	}
}
