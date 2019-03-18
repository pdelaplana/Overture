using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Overture.Core.Services
{
    public interface IAuthenticationService
    {
		Task<AuthenticationResult> AuthenticateAsync(string userId, string password);
		Task<AuthenticationResult> AuthenticateByEmailAsync(string email, string password);
    }
}
