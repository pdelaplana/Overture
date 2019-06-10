using System;
using System.Collections.Generic;
using System.Text;
using Overture.Core.Domain.ValueObjects;

namespace Overture.Core.Application.Models
{
    public class UserModel
    {
		public string UserId { get; set; }

		public string Email { get; set; }
		public string Name { get; set; }
		public StoredFile Picture { get; set; }
		public string AccountType { get; set; }

	}
}
