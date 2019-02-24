using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Infrastructure.Services.Auth0
{
    public class Auth0Settings
    {
		public string Token { get; set; }
		public string Domain { get; set; }
		public string Audience { get; set; }
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }

    }
}
