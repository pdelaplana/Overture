using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.Models;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.Jobs;


namespace Overture.Web.API.Controllers
{
	[Route("api/jobs")]
	[ApiController]
	public class JobsController : OvertureController
	{
		// POST api/jobs
		[HttpPost]
		[Authorize]
		public async Task<ActionResult<UseCaseResult<JobModel>>> Post([FromBody]CreateJob request)
		{
			return Ok(await UseCase.Execute(request));
		}

		// PUT api/jobs
		[HttpPut]
		[Authorize]
		public async Task<ActionResult<UseCaseResult<JobModel>>> Put([FromBody]UpdateJob request)
		{
			return Ok(await UseCase.Execute(request));
		}

		// GET api/jobs
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<UseCaseResult<IEnumerable<JobModel>>>> Get([FromQuery]GetJobs request)
		{
			return Ok(await UseCase.Execute(request));
		}

		// GET api/jobs
		[HttpGet("{id:Guid}/detail")]
		[Authorize]
		public async Task<ActionResult<UseCaseResult<JobModel>>> Get(Guid id)
		{
			return Ok(await UseCase.Execute(new GetJob { Id = id }));
		}



	}
}