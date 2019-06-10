using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Repositories;
using Overture.Core.Services;
using Overture.Core.Domain.Entities;

namespace Overture.Core.Application.UseCases.ManageUsers
{
    public class CreateUser : UseCase<UserModel>
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public AccountType AccountType { get; set; }

    }

	public class CreateUserHandler : IUseCaseHandler<CreateUser, UserModel>
	{
		private readonly IUserService _userService = null;
		private readonly IBusinessRepository _businessRepository = null;
		private readonly IMapper _mapper = null;

		public CreateUserHandler(
			IUserService userService, 
			IBusinessRepository businessRepository,
			IMapper mapper)
		{
			_userService = userService;
			_businessRepository = businessRepository;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<UserModel>> Handle(CreateUser request, CancellationToken cancellationToken)
		{
			try
			{
				var user = await _userService.CreateUserAsync(
					new OvertureUser
					{
						Email = request.Email,
						AccountType = request.AccountType
					}, 
					request.Password);

				if (request.AccountType == AccountType.Business)
				{
					// create the business profile record
					await _businessRepository.AddAsync(new Business { UserId = user.UserId, IsTrading = false });
				}

				return new UseCaseResult<UserModel>
				{
					ResultCode = "Ok",
					ResultText = "CreateUser",
					Data = _mapper.Map<UserModel>(user),
				};
			}
			catch (Exception e)
			{
				return new UseCaseResult<UserModel>
				{
					ResultCode = "Error",
					ResultText = e.Message,
					Data = null
				};
			}
			
		}
	}


}
