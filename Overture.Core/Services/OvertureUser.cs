using System;
using System.Collections.Generic;
using System.Text;
using Overture.Core.Domain.ValueObjects;

namespace Overture.Core.Services
{
	public enum AccountType
	{
		Administrator,
		Personal,
		Consumer,
		Business
	}
	public class OvertureUser
	{
		public string UserId { get; set; }

		public string Email { get; set; }
		public string Name { get; set; }
		public StoredFile Picture { get; set; }
		public AccountType AccountType { get; set; }
		
    }
}
