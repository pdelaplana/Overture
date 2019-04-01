using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Repositories;
using Overture.Core.Domain.Entities;

namespace Overture.Core.Application.UseCases.ManageBusinesses
{
    public class CreateBusiness : UseCase<BusinessModel>
    {
		public string Name { get; set; }
		public string Owner { get; set; }
		public string Description { get; set; }
		public string[] Services { get; set; }
    }

	public class CreateBusinessHandler : IUseCaseHandler<CreateBusiness, BusinessModel>
	{
		private IBusinessRepository _repository = null;
		private IBusinessServiceRepository _businessServiceRepository = null;
		private IMapper _mapper = null;

		public CreateBusinessHandler(IBusinessRepository repository, 
			IBusinessServiceRepository businessServicesRepository, 
			IMapper mapper)
		{
			_repository = repository;
			_businessServiceRepository = businessServicesRepository;
			_mapper = mapper;
		}
		public async Task<UseCaseResult<BusinessModel>> Handle(CreateBusiness request, CancellationToken cancellationToken)
		{

			try
			{
				return new UseCaseResult<BusinessModel>
				{
					ResultCode = "Ok",
					ResultText = "CreateBusiness",
					Data = _mapper.Map<BusinessModel>(await _repository.AddAsync(new Business
					{
						Name = request.Name,
						Owner = request.Owner,
						Description = request.Description,
						BusinessServices = _businessServiceRepository.All().Where(s => request.Services.Contains(s.Name)).ToList()
					}))
				};
			}
			catch (Exception e)
			{
				return new UseCaseResult<BusinessModel>
				{
					ResultCode = "Error",
					ResultText = e.Message,
					Data = null
				};

			}
			
		}
	}
}
