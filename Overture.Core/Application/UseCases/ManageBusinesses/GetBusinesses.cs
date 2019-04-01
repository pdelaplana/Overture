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
    public class GetBusinesses : UseCase<IEnumerable<BusinessModel>>
    {
		public int? Page { get; set; }
		public int? Size { get; set; }
		public string[] Services { get; set; }
		public string[] Areas { get; set; }
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
					var query = _businessRepository.All();
					if (request.Services != null)
					{
						query = query.Where(b => b.BusinessServices.Any(s => request.Services.Contains(s.Name)|| request.Services.Contains(s.CategoryName))); // this works
					}
					if (request.Areas != null)
					{
						query = query.Where(b => b.ServiceAreas.Any(s => request.Areas.Contains(s.Name)));
					}
					if (request.Page.HasValue && request.Size.HasValue)
					{
						query = query.Skip(request.Page.Value * request.Size.Value).Take(request.Size.Value);
					}
					else
					{
						// limit results to 500
						query.Take(500);
					}

					return UseCaseResult<IEnumerable<BusinessModel>>.Create(_mapper.Map<IEnumerable<BusinessModel>>(query.ToList()), resultText: "GetBusinesses");
				});
			}
			catch (Exception e)
			{
				return UseCaseResult<IEnumerable<BusinessModel>>.CreateError(resultText: e.Message);
			}
			
			
		}
	}
}
