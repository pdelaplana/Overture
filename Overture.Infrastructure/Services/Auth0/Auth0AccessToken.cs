using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Infrastructure.Services.Auth0
{
    public class Auth0AccessToken
    {
		public string AccessToken { get; set; }
		public int ExpiresIn { get; set; }
		public string Scope { get; set; }
		public string TokenType { get; set; }
    }
}
