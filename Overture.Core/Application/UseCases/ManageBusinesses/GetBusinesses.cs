using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Repositories;

namespace Overture.Core.Application.UseCases.ManageBusinesses
{
    public class GetBusinesses : IUseCase<IEnumerable<BusinessModel>>
    {
	
    }

	public class GetBusinessesHandler : IUseCaseHandler<GetBusinesses, IEnumerable<BusinessModel>>
	{
		private readonly IBusinessRepository _businessRepository = null;
		private readonly IMapper _mapper = null;

		public GetBusinessesHandler(IBusinessRepository businessRepository, IMapper mapper)
		{
			_businessRepository = businessRepository;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<IEnumerable<BusinessModel>>> Handle(GetBusinesses request, CancellationToken cancellationToken)
		{

			try
			{
				return await Task.Run(() =>
				{
					return UseCaseResult<IEnumerable<BusinessModel>>.Create(_mapper.Map<IEnumerable<BusinessModel>>(_businessRepository.All().ToList()), resultText: "GetBusinesses");
				});
			}
			catch (Exception e)
			{
				return UseCaseResult<IEnumerable<BusinessModel>>.CreateError(resultText: e.Message);
			}
			
			
		}
	}
}
