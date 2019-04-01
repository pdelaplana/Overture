using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;

namespace Overture.Core.Application.UseCases.ManageServices
{
	
	public class CreateBusinessService : UseCase<Models.BusinessServiceModel>
	{
		public string Name { get; set; }
		public string CategoryName { get; set; }
    }

	public class CreateBusinessServiceHandler : IUseCaseHandler<CreateBusinessService, Models.BusinessServiceModel>
	{
		private IBusinessServiceRepository _repository = null;
		private IBusinessServiceCategoryRepository _categoryRepository = null;
		private IMapper _mapper = null;

		public CreateBusinessServiceHandler(IBusinessServiceRepository repository, IBusinessServiceCategoryRepository categoryRepository, IMapper mapper)
		{
			_repository = repository;
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}
		public async Task<UseCaseResult<Models.BusinessServiceModel>> Handle(CreateBusinessService request, CancellationToken cancellationToken)
		{
			try
			{
				
				return new UseCaseResult<Models.BusinessServiceModel>
				{
					ResultCode = "Ok",
					ResultText = "CreateBusinessService",
					Data = _mapper.Map<Models.BusinessServiceModel>(await _repository.AddAsync(new Domain.Entities.BusinessService
					{
						Name = request.Name,
						CategoryName= request.CategoryName
					}))
				};
			}
			catch (Exception e)
			{
				return new UseCaseResult<Models.BusinessServiceModel>
				{
					ResultCode = "Error",
					ResultText = e.Message,
				};
			}
			
		}
	}
}
