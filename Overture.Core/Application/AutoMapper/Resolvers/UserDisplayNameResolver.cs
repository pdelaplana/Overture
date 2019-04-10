using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Domain.Entities;
using Overture.Core.Application.Models;
using Overture.Core.Services;

namespace Overture.Core.Application.AutoMapper.Resolvers
{
	public class UserDisplayNameResolver : IMemberValueResolver<object, object, string, string>
	{
		private readonly IUserService _userService;
		
		public UserDisplayNameResolver(IUserService userService)
		{
			_userService = userService;
		}

		public string Resolve(object source, object destination, string sourceMember, string destMember, ResolutionContext context)
		{
			
			var user = Task.Run(async () =>  await _userService.GetUserAsync(sourceMember)).Result;
			if (user != null)
			{
				return user.DisplayName;
			} else
			{
				return "";
			}
			
		}
	}
}
