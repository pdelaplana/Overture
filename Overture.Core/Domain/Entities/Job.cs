using System;
using System.Collections.Generic;
using System.Text;
using Overture.Core.Domain.ValueObjects;

namespace Overture.Core.Domain.Entities
{
    public class Job : IEntity
    {
		public Guid Id { get; set; }
		public string UserId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public IEnumerable<Quote> Quotes { get; set; }

		public DateTime RequiredDate { get; set; }
		public DateTime ExpiryDate { get; set; }
		public DateTime? CancelledDate { get; set; }
		public DateTime? CompletedDate { get; set; }

	}
}
