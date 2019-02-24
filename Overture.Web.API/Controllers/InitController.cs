using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application;
using Overture.Core.Application.Models;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.Administrator;


namespace Overture.Web.API.Controllers
{
    [Route("api/init")]
    [ApiController]
    public class InitController : OvertureController
    {
		// POST api/init
		[HttpPost]
		public async Task<ActionResult<UseCaseResult<InitializeDataModel>>> Post([FromBody]InitializeData request)
		{
			return Ok(await UseCase.Execute(request));
		}

	}
}