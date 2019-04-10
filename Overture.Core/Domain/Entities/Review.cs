using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Domain.Entities
{
	public class Review : IEntity
	{
		public Guid Id { get; set; }
		public Guid BusinessId { get; set; }
		public string Reviewer { get; set; } 
		public DateTime ReviewDate { get; set; }
		public string Content { get; set; }
		public int Rating { get; set; }
		public bool Satisfied { get; set; }
		public bool Recommend { get; set; }
		public bool Rehire { get; set; }
		public bool OnTime { get; set; }
		public bool OnBudget { get; set; }
    }
}
