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
    public class GetBusiness : IUseCase<BusinessModel>
    {
		public string UserId { get; set; }
    }

	public class GetBusinessHandler : IUseCaseHandler<GetBusiness, BusinessModel>
	{
		private readonly IBusinessRepository _businessRepository = null;
		private readonly IMapper _mapper = null;

		public GetBusinessHandler(IBusinessRepository businessRepository, IMapper mapper)
		{
			_businessRepository = businessRepository;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<BusinessModel>> Handle(GetBusiness request, CancellationToken cancellationToken)
		{

			try
			{
				if (!string.IsNullOrEmpty(request.UserId))
				{
					return await Task.Run(() =>
					{
						return UseCaseResult<BusinessModel>.Create(_mapper.Map<BusinessModel>(_businessRepository.All().Where(b => b.UserId == request.UserId).SingleOrDefault()), resultText: "GetBusiness");
					});
				}
				else
				{
					return UseCaseResult<BusinessModel>.CreateError(resultText: "No User Id");
				}
			}
			catch (Exception e)
			{
				return UseCaseResult<BusinessModel>.CreateError(resultText: e.Message);
			}
			
			
		}
	}
}
