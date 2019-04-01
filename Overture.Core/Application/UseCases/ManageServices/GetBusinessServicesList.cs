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
	public class GetBusinessServicesList : UseCase<IEnumerable<BusinessServiceModel>>
	{
	}

	public class GetBusinessServicesListHandler : IUseCaseHandler<GetBusinessServicesList, IEnumerable<BusinessServiceModel>>
	{
		private IBusinessServiceRepository _repository = null;
		private IMapper _mapper = null;

		public GetBusinessServicesListHandler (IBusinessServiceRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<UseCaseResult<IEnumerable<BusinessServiceModel>>> Handle(GetBusinessServicesList request, CancellationToken cancellationToken)
		{
			try
			{
				return await Task.Run(() =>
				{
					return new UseCaseResult<IEnumerable<BusinessServiceModel>>
					{
						ResultCode = "Ok",
						ResultText = "GetBusinessSevices",
						Data = _mapper.Map<List<BusinessServiceModel>>(_repository.All().ToList())
					};
				});
			}
			catch (Exception e)
			{
				return new UseCaseResult<IEnumerable<BusinessServiceModel>>
				{
					ResultCode = "Error",
					ResultText = e.Message
				};
			}
			
		}
	}
}
