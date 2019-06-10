using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Overture.Core.Application.Models;
using Overture.Core.Services;

namespace Overture.Core.Application.UseCases.ManageUsers
{
    public class AuthenticateUser : UseCase<AuthenticatedUserModel>
    {
		public string Email { get; set; }
		public string Password { get; set; }
    }

	public class AuthenticateUserHandler : IUseCaseHandler<AuthenticateUser, AuthenticatedUserModel>
	{
		private readonly IAuthenticationService _authenticationService = null;
		private readonly IUserService _userService = null;
		private readonly IMapper _mapper = null;

		public AuthenticateUserHandler(
			IAuthenticationService authenticationService, 
			IUserService userService,
			IMapper mapper)
		{
			_authenticationService = authenticationService;
			_userService = userService;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<AuthenticatedUserModel>> Handle(AuthenticateUser request, CancellationToken cancellationToken)
		{
			var result = await _authenticationService.AuthenticateAsync(request.Email, request.Password);
			if (result != null)
			{
				var user = await _userService.GetUserByEmailAsync(request.Email);
				// current signin info
				if (user != null)
				{
					var model = _mapper.Map<AuthenticatedUserModel>(user);
					model.AccessToken = result.AccessToken;
					model.IdToken = result.IdToken;
					model.ExpiresIn = result.ExpiresIn;
					model.LastSigninDate = DateTime.UtcNow;
					return UseCaseResult<AuthenticatedUserModel>.Create(model);
				}
				
			}
			return UseCaseResult<AuthenticatedUserModel>.CreateError();

		}
	}
}
