using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Overture.Core.Application.UseCases
{
	
	public class UseCaseInteractor
	{
		public IMediator Mediator {get; set;}
		public async Task<UseCaseResult<TResultModel>> Execute<TResultModel>(IUseCase<TResultModel> useCase)
		{
			return await Mediator.Send(useCase);
			
		}
    }
}
