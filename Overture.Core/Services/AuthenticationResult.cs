using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Services
{
    public class AuthenticationResult
    {
		public string TokenType { get; set; }
		public string AccessToken { get; set; }
		public string IdToken { get; set; }
		public int ExpiresIn { get; set; }
	}
}
