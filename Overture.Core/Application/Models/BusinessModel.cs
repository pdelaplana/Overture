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
		public string AltReference { get; set; }
		public string Owner { get; set; }
		public string Description { get; set; }
		public string Tagline { get; set; }
		public bool IsTrading { get; set; }
		public bool IsVerified { get; set; }
		public FileAttachment Picture { get; set; }
		public Address Address { get; set; }
		public IEnumerable<BusinessServiceModel> BusinessServices { get; set; }
		public IEnumerable<ServiceArea> ServiceAreas { get; set; }
		public IEnumerable<ContactMethod> ContactMethods { get; set; }
		public IEnumerable<FileAttachmentModel> FileAttachments { get; set; }
	}
}
