using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Services
{
    public class OvertureUser
    {
		public string UserId { get; set; }

		public string Email { get; set; }
		public string Name { get; set; }
		public string DisplayName { get; set; }

		public bool RegisteredAsBusiness { get; set; }
	

		public byte[] Picture { get; set; }
    }
}
