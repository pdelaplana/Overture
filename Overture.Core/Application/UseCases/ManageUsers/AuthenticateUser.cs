using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Overture.Core.Services;

namespace Overture.Core.Application.UseCases.ManageUsers
{
    public class AuthenticateUser : UseCase<OvertureUser>
    {
		public string Email { get; set; }
		public string Password { get; set; }
    }

	public class AuthenticateUserHandler : IUseCaseHandler<AuthenticateUser, OvertureUser>
	{
		private readonly IAuthenticationService _authenticationService = null;
		private readonly IUserService _userService = null;

		public AuthenticateUserHandler(IAuthenticationService authenticationService, IUserService userService)
		{
			_authenticationService = authenticationService;
			_userService = userService;
		}

		public async Task<UseCaseResult<OvertureUser>> Handle(AuthenticateUser request, CancellationToken cancellationToken)
		{
			var result = await _authenticationService.AuthenticateAsync(request.Email, request.Password);
			if (result != null)
			{
				var user = await _userService.GetUserByEmailAsync(request.Email);
				// current signin info
				if (user != null)
				{
					user.AccessToken = result.AccessToken;
					user.IdToken = result.IdToken;
					user.ExpiresIn = result.ExpiresIn;
					user.LastSigninDate = DateTime.UtcNow;
					return UseCaseResult<OvertureUser>.Create(user);
				}
				
			}
			return UseCaseResult<OvertureUser>.CreateError();

		}
	}
}
