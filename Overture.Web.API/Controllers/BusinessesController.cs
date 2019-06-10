using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.Models;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.ManageBusinesses;
using Overture.Core.Domain.Entities;

namespace Overture.Web.API.Controllers
{
    [Route("api/businesses")]
    [ApiController]
    public class BusinessesController : OvertureController
    {
		// GET api/businesses
		[HttpGet]
		public async Task<ActionResult<UseCaseResult<IEnumerable<BusinessModel>>>> Get([FromQuery]GetBusinesses request)
		{
			return Ok(await UseCase.Execute(request));
		}

	}
}