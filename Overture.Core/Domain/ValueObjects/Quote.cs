using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Domain.ValueObjects
{
	public class Quote 
	{
		public Guid QuotedByBusinessId { get; set; }

		public DateTime? QuotedDate { get; set; }
		public DateTime? AcceptedDate { get; set; }

		public decimal QuotedFixedRate { get; set; }
		public decimal QuotedHourlyRate { get; set; }

	}
}
