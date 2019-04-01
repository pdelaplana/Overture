using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Overture.Core.Services;

namespace Overture.Core.Application.UseCases.ManageUsers
{
    public class GetUserByEmail : UseCase<OvertureUser>
    {
		public string Email { get; set; }
    }

	public class GetUserByEmailHandler : IUseCaseHandler<GetUserByEmail, OvertureUser>
	{
		public IUserService _userService = null;

		public GetUserByEmailHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<UseCaseResult<OvertureUser>> Handle(GetUserByEmail request, CancellationToken cancellationToken)
		{
			try
			{
				return new UseCaseResult<OvertureUser>
				{
					ResultCode = "Ok",
					ResultText = "GetUserByEmail",
					Data = await _userService.GetUserByEmailAsync(request.Email)
				};
			}
			catch (Exception e)
			{
				return new UseCaseResult<OvertureUser>
				{
					ResultCode = "Error",
					ResultText = e.Message
				};
			}
		}
	}
}
