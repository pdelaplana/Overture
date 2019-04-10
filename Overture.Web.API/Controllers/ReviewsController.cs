using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.Reviews;
using Overture.Core.Application.Models;

namespace Overture.Web.API.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : OvertureController
    {
		// POST api/reviews
		[HttpPost]
		[Authorize]
		public async Task<ActionResult<UseCaseResult<ReviewModel>>> Post([FromBody]CreateReview request)
		{
			return Ok(await UseCase.Execute(request));
		}

		// GET api/reviews
		[HttpGet]
		public async Task<ActionResult<UseCaseResult<ReviewModel>>> Get([FromQuery]GetReviews request)
		{
			return Ok(await UseCase.Execute(request));
		}
	}
}