using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Application.Models
{
    public class BusinessServiceCategoryModel
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int CountOfServices { get; set; }
		public int CountOfBusinesses { get; set; }

		public IEnumerable<BusinessServiceModel> BusinessServices { get; set; }
	}
}
