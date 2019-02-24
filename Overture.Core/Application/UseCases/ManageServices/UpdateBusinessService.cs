using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application;
using Overture.Core.Application.Models;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;

namespace Overture.Core.Application.UseCases.ManageServices
{
	
	public class UpdateBusinessService : IUseCase<Models.BusinessServiceModel>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
    }

	public class UpdateBusinessServiceHandler : IUseCaseHandler<UpdateBusinessService, Models.BusinessServiceModel>
	{
		private IBusinessServiceRepository _repository = null;
		private IMapper _mapper = null;

		public UpdateBusinessServiceHandler(IBusinessServiceRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<UseCaseResult<Models.BusinessServiceModel>> Handle(UpdateBusinessService request, CancellationToken cancellationToken)
		{
			try
			{
				if (_repository.All().Where(s => s.Name == request.Name).Any())
				{
					throw new ArgumentException($"Request.Name {request.Name} is in use.");
				}
				return new UseCaseResult<Models.BusinessServiceModel>
				{
					ResultCode = "Ok",
					ResultText = "UpdateBusinessService",
					Data = _mapper.Map<Models.BusinessServiceModel>(await _repository.UpdateAsync(new Domain.Entities.BusinessService {
						Id = request.Id,
						Name = request.Name
					}))

				};
			}
			catch (Exception e)
			{
				return new UseCaseResult<Models.BusinessServiceModel>
				{
					ResultCode = "Error",
					ResultText = e.Message,
					Data = null

				};
			}
			
			
		}
	}
}
