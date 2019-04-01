using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Overture.Core.Application.UseCases
{
	public interface IUseCase<TModel> : IRequest<UseCaseResult<TModel>>
	{
		UseCaseContext Context { get; set; }
	}
}
