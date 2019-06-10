using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Application.Models
{
    public class JobModel
    {
		public Guid Id { get; set; }
		public string UserId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public IEnumerable<QuoteModel> Quotes { get; set; }

		public DateTime RequiredDate { get; set; }
		public DateTime? CompletedDate { get; set; }

		public bool IsCancelled { get; set; }

	}
}
