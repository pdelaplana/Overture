using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Overture.Core.Repositories;
using Overture.Core.Services;
using Overture.Core.Domain.Entities;

namespace Overture.Core.Application.UseCases.ManageUsers
{
    public class CreateUser : IUseCase<OvertureUser>
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public bool RegisterAsBusiness { get; set; }

    }

	public class CreateUserHandler : IUseCaseHandler<CreateUser, OvertureUser>
	{
		private readonly IUserService _userService = null;
		private readonly IBusinessRepository _businessRepository = null;

		public CreateUserHandler(IUserService userService, IBusinessRepository businessRepository)
		{
			_userService = userService;
			_businessRepository = businessRepository;
		}

		public async Task<UseCaseResult<OvertureUser>> Handle(CreateUser request, CancellationToken cancellationToken)
		{
			try
			{
				var user = await _userService.CreateUserAsync(
					new OvertureUser
					{
						Email = request.Email,
						RegisteredAsBusiness = request.RegisterAsBusiness
					}, 
					request.Password);

				if (request.RegisterAsBusiness)
				{
					// create the business profile record
					await _businessRepository.AddAsync(new Business { UserId = user.UserId, IsTrading = false });
				}

				return new UseCaseResult<OvertureUser>
				{
					ResultCode = "Ok",
					ResultText = "CreateUser",
					Data = user,
				};
			}
			catch (Exception e)
			{
				return new UseCaseResult<OvertureUser>
				{
					ResultCode = "Error",
					ResultText = e.Message,
					Data = null
				};
			}
			
		}
	}


}
