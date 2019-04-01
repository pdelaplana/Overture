using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Application.UseCases
{
	public class UseCase<TModel> : IUseCase<TModel>
	{
		public UseCaseContext Context { get; set; }
	}
}
