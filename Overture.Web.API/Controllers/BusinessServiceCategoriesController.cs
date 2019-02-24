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
using Overture.Core.Application.UseCases.ManageServiceCategories;


namespace Overture.Web.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class BusinessServiceCategoriesController : OvertureController
	{
		// GET api/services
		[HttpGet]
		public async Task<ActionResult<UseCaseResult<IEnumerable<BusinessServiceCategoryModel>>>> Get([FromQuery]GetBusinessServiceCategoriesList request)
		{
			return Ok(await UseCase.Execute(request));
		}
	}
}