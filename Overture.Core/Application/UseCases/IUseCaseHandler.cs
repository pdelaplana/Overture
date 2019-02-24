using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Overture.Core.Application.UseCases
{
	public interface IUseCaseHandler<TUseCase, TResultModel> : IRequestHandler<TUseCase, UseCaseResult<TResultModel>> 
		where TUseCase : IUseCase<TResultModel> { }

}
