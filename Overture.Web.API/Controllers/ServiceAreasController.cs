using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.MetaInformation;
using Overture.Core.Domain.ValueObjects;

namespace Overture.Web.API.Controllers
{
	[Route("api/service_areas")]
	[ApiController]
	public class ServiceAreasController : OvertureController
	{
		// GET api/service_areas
		[HttpGet]
		public async Task<ActionResult<UseCaseResult<ServiceArea>>> Get([FromQuery]GetServiceAreas request)
		{
			return Ok(await UseCase.Execute(request));
		}

	}
}