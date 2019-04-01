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
    public class GetBusiness : UseCase<BusinessModel>
    {
		public string UserId { get; set; }
		public string Name { get; set; }
		public string AltReference { get; set; }

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
				var query = _businessRepository.All();
				if (!string.IsNullOrEmpty(request.Name))
				{
					query = query.Where(b => b.Name == request.Name);
				}
				else if (!string.IsNullOrEmpty(request.AltReference))
				{

					query = query.Where(b => b.AltReference == request.AltReference);
				}
				else if (!string.IsNullOrEmpty(request.UserId))
				{

					query = query.Where(b => b.UserId == request.UserId);
				}
				else
				{
					return UseCaseResult<BusinessModel>.CreateError(resultText: "No User Id");
				}

				return await Task.Run(() =>
				{
					return UseCaseResult<BusinessModel>.Create(_mapper.Map<BusinessModel>(query.SingleOrDefault()), resultText: "GetBusiness");
				});
			}
			catch (Exception e)
			{
				return UseCaseResult<BusinessModel>.CreateError(resultText: e.Message);
			}
			
			
		}
	}
}
