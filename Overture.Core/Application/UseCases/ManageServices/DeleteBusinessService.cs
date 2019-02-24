using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Overture.Core.Application;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;

namespace Overture.Core.Application.UseCases.ManageServices
{
	
	public class DeleteBusinessService : IUseCase<Boolean>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
    }

	public class DeleteBusinessServiceHandler : IUseCaseHandler<DeleteBusinessService, Boolean>
	{
		private IBusinessServiceRepository _repository = null;

		public DeleteBusinessServiceHandler(IBusinessServiceRepository repository)
		{
			_repository = repository;
		}
		public async Task<UseCaseResult<bool>> Handle(DeleteBusinessService request, CancellationToken cancellationToken)
		{
			try
			{
				if (request.Id == Guid.Empty)
				{
					var businessService = _repository.All().Where(s => s.Name == request.Name).SingleOrDefault();
					if (businessService != null)
					{
						request.Id = businessService.Id;
					}
				}

				if (request.Id == Guid.Empty)
				{
					throw new ArgumentNullException($"Request Id is null");
				}

				return new UseCaseResult<bool>
				{
					ResultCode = "Ok",
					ResultText = "DeleteBusinessServiceUseCase",
					Data = await _repository.DeleteAsync(new BusinessService { Id = request.Id })
				};

			}
			catch (Exception e)
			{
				return new UseCaseResult<bool>
				{
					ResultCode = "Error",
					ResultText = e.Message,
					Data = false
				};


			}

		}

		
	}
}
