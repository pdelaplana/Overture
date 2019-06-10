using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.ManageUsers;
using Overture.Core.Services;

namespace Overture.Web.API.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : OvertureController
	{
		// GET api/services
		[HttpGet]
		public async Task<ActionResult<UseCaseResult<OvertureUser>>> GetByEmail([FromQuery]GetUserByEmail request)
		{
			return Ok(await UseCase.Execute(request));

		}

		// PUT api/users
		[HttpPut]
		public async Task<ActionResult<UseCaseResult<OvertureUser>>> Put([FromBody]UpdateUser request)
		{
			return Ok(await UseCase.Execute(request));
		}
	
	}
}