using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    [Route("api/business")]
    [ApiController]
    public class BusinessController : OvertureController
    {
		
		// POST api/business
		[HttpPost]
		[Authorize]
		public async Task<ActionResult<UseCaseResult<BusinessModel>>> Post([FromBody]CreateBusiness request)
		{
			return Ok(await UseCase.Execute(request));
		}

		// PUT api/business
		[HttpPut]
		[Authorize]
		public async Task<ActionResult<UseCaseResult<BusinessModel>>> Put([FromBody]UpdateBusiness request)
		{
			
			return Ok(await UseCase.Execute(request));
		}

		// GET api/business
		[HttpGet]
		public async Task<ActionResult<UseCaseResult<BusinessModel>>> Get([FromQuery]GetBusiness request)
		{
			return Ok(await UseCase.Execute(request));
		}

	}
}