using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Application.Models
{
    public class QuoteModel
    {
		public Guid QuotedByBusinessId { get; set; }
		public string BusinessName { get; set; }

		public DateTime? QuotedDate { get; set; }
		public DateTime? AcceptedDate { get; set; }

		public decimal QuotedFixedRate { get; set; }
		public decimal QuotedHourlyRate { get; set; }
	}
}
