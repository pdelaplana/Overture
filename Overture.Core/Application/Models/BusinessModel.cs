using System;
using System.Collections.Generic;
using System.Text;
using Overture.Core.Domain.ValueObjects;

namespace Overture.Core.Application.Models
{
    public class BusinessModel
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Owner { get; set; }
		public string Description { get; set; }
		public string TagLine { get; set; }
		public IEnumerable<ServiceArea> ServiceAreas { get; set; }
		//public Address Address { get; set; }
		public IEnumerable<BusinessServiceModel> BusinessServices { get; set; }
	}
}
