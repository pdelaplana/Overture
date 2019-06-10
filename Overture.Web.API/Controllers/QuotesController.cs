using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.Models;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.Quotes;

namespace Overture.Web.API.Controllers
{
    [Route("api/quotes")]
    [ApiController]
    public class QuotesController : OvertureController
    {
		// POST api/quotes
		[HttpPost]
		[Authorize]
		public async Task<ActionResult<UseCaseResult<JobModel>>> Post([FromBody]RequestQuote request)
		{
			return Ok(await UseCase.Execute(request));
		}
	}
}