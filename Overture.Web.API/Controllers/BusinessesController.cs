using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.Models;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.ManageBusinesses;
using Overture.Core.Domain.Entities;

namespace Overture.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesController : OvertureController
    {
		
		// POST api/business
		[HttpPost]
		public async Task<ActionResult<UseCaseResult<Business>>> Post([FromBody]CreateBusiness request)
		{
			return Ok(await UseCase.Execute(request));
		}

		// GET api/business
		[HttpGet]
		public async Task<ActionResult<UseCaseResult<BusinessModel>>> Get([FromBody]GetBusiness request)
		{
			return Ok(await UseCase.Execute(request));
		}

		
	}
}