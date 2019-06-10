using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Application.Models
{
    public class AuthenticatedUserModel : UserModel
    {
		public DateTime LastSigninDate { get; set; }
		public string AccessToken { get; set; }
		public string IdToken { get; set; }
		public int ExpiresIn { get; set; }
	}
}
