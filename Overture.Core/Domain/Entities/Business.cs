using System;
using System.Collections.Generic;
using System.Text;
using Overture.Core.Domain.ValueObjects;

namespace Overture.Core.Domain.Entities
{
	public class Business : IEntity
	{
		public Guid Id { get; set; }
		public string UserId { get; set; }
		public string Name { get; set; }
		public string Owner { get; set; }
		public string TagLine { get; set; }
		public string Description { get; set; }  
		public decimal MinumumRate { get; set; }
		public bool IsTrading { get; set; }
		public Address Address { get; set; }
		public IEnumerable<BusinessService> BusinessServices { get; set; }
		public IEnumerable<ServiceArea> ServiceAreas { get; set; }

	}
}
