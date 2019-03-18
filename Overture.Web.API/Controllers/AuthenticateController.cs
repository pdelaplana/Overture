using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.UseCases.ManageUsers;

namespace Overture.Web.API.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticateController : OvertureController
    {
      
        // POST: api/authentication
        [HttpPost]
        //public async Task<ActionResult<UseCaseResult<OvertureUser>>> Post([FromBody] AuthenticateUser request)
		public async Task<ActionResult> Post([FromBody]AuthenticateUser request)
		{
			return Ok(await UseCase.Execute(request));
        }

    }
}
