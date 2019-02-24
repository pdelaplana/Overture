using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Overture.Core.Services
{
    public interface IUserService
    {
		Task<OvertureUser> CreateUserAsync(OvertureUser user, string password);
		Task<OvertureUser> GetUserByEmailAsync(string email);
    }
}
