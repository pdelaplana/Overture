using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Overture.Core.Application.Models;
using Overture.Core.Application.UseCases;
using Overture.Core.Domain.Entities;
using Overture.Core.Application.UseCases.ManageServices;

namespace Overture.Web.API.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Route("api/services")]
    public class BusinessServicesController : OvertureController
    {
		
		public BusinessServicesController()
		{
		}

		// GET api/services
		[HttpGet]
		public async Task<ActionResult<UseCaseResult<IEnumerable<BusinessServiceModel>>>> Get()
		{
			return Ok(await UseCase.Execute(new GetBusinessServicesList()));

		}
		// POST api/services
		[HttpPost]
		public async Task<ActionResult<UseCaseResult<BusinessServiceModel>>> Post([FromBody]CreateBusinessService request)
		{
			return Ok(await UseCase.Execute(request));
		}
		// PUT api/services
		[HttpPut]
		public async Task<ActionResult<UseCaseResult<BusinessServiceModel>>> Put([FromBody]UpdateBusinessService request)
		{
			return Ok(await UseCase.Execute(request));
		}
		// PUT api/services
		[HttpDelete]
		public async Task<ActionResult<UseCaseResult<BusinessServiceModel>>> Delete([FromBody]DeleteBusinessService request)
		{
			return Ok(await UseCase.Execute(request));
		}
	}
}