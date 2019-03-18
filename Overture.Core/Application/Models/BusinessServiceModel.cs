using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Application.Models
{
    public class BusinessServiceModel
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid BusinessServiceCategoryId { get; set; }
		public string CategoryName { get; set; }
		public int CountOfBusinesses { get; set; }
	}
}
