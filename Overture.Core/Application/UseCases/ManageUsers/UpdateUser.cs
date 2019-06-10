using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Domain.ValueObjects;
using Overture.Core.Services;

namespace Overture.Core.Application.UseCases.ManageUsers
{
    public class UpdateUser :UseCase<UserModel>
    {
		public string UserId { get; set; }
		public string Name { get; set; }
		public StoredFile Picture { get; set; }
		public AccountType AccountType { get; set; }
    }

	public class UpdateUserHandler : IUseCaseHandler<UpdateUser, UserModel>
	{
		private readonly IUserService _userService = null;
		private readonly IMapper _mapper = null;

		public UpdateUserHandler(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<UserModel>> Handle(UpdateUser request, CancellationToken cancellationToken)
		{
			try
			{
				var user = await _userService.GetUserAsync(request.UserId);

				if (user != null)
				{
					user.Name = request.Name;
					user.Picture = request.Picture;
					user.AccountType = request.AccountType;
				}

				return UseCaseResult<UserModel>.Create(_mapper.Map<UserModel>(await _userService.UpdateUserAsync(user)));
			}
			catch (Exception e)
			{
				return UseCaseResult<UserModel>.CreateError(e.Message);
			}
		}
	}

}
