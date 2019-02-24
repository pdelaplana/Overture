using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.UseCases.ManageUsers;

namespace Overture.Web.API.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : OvertureController
    {
		
		// POST api/registration
		[HttpPost]
		public async Task<ActionResult> Post([FromBody]CreateUser request)
		{
			return Ok(await UseCase.Execute(request));
		}
	}
}