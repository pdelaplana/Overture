using System;
using System.Collections.Generic;
using System.Text;
using Overture.Core.Domain.ValueObjects;

namespace Overture.Core.Application
{
    public class MetaInformation
    {
		public Guid Id { get; set; }
		public IEnumerable<ServiceArea> ServiceAreas { get; set; }
		public IEnumerable<ServiceCategory> ServiceCategories { get; set; }

		public string[] ContactMethodTypes { get; set; }
    }
}
