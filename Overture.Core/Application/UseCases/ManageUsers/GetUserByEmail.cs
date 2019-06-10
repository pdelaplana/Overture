using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Services;

namespace Overture.Core.Application.UseCases.ManageUsers
{
    public class GetUserByEmail : UseCase<UserModel>
    {
		public string Email { get; set; }
    }

	public class GetUserByEmailHandler : IUseCaseHandler<GetUserByEmail, UserModel>
	{
		private readonly IUserService _userService = null;
		private readonly IMapper _mapper = null;

		public GetUserByEmailHandler(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<UserModel>> Handle(GetUserByEmail request, CancellationToken cancellationToken)
		{
			try
			{
				return new UseCaseResult<UserModel>
				{
					ResultCode = "Ok",
					ResultText = "GetUserByEmail",
					Data = _mapper.Map<UserModel>(await _userService.GetUserByEmailAsync(request.Email))
				};
			}
			catch (Exception e)
			{
				return new UseCaseResult<UserModel>
				{
					ResultCode = "Error",
					ResultText = e.Message
				};
			}
		}
	}
}
