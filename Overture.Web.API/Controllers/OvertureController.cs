using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Overture.Core.Application.UseCases;
using MediatR;

namespace Overture.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class OvertureController : ControllerBase
    {
		private UseCaseInteractor _usecase;

		protected UseCaseInteractor UseCase => _usecase ?? (_usecase = new UseCaseInteractor { Mediator = HttpContext.RequestServices.GetService<IMediator>() });
	}
}