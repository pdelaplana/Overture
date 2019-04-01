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

namespace Overture.Core.Application.UseCases.ManageServiceCategories
{
	public class GetBusinessServiceCategoriesList : UseCase<IEnumerable<BusinessServiceCategoryModel>>
	{
		public bool Top10 { get; set; }
	}
	public class GetBusinessServicesListHandler : IUseCaseHandler<GetBusinessServiceCategoriesList, IEnumerable<BusinessServiceCategoryModel>>
	{
		private IBusinessServiceRepository _businessServiceRepository = null;
		private IBusinessRepository _businessRepository = null;
		private IMapper _mapper = null;

		public GetBusinessServicesListHandler(
			IBusinessServiceRepository businessServiceRepository,
			IBusinessRepository businessRepository,
			IMapper mapper)
		{
			_businessServiceRepository = businessServiceRepository;
			_businessRepository = businessRepository;
			_mapper = mapper;
		}
		public async Task<UseCaseResult<IEnumerable<BusinessServiceCategoryModel>>> Handle(GetBusinessServiceCategoriesList request, CancellationToken cancellationToken)
		{
			try
			{
				return await Task.Run(() =>
				{
					//var services = _businessRepository.All().GroupBy(b => b.BusinessServices.GroupBy(s => s.CategoryName).Select(s => s.Key)).ToList();
					var query = _businessServiceRepository.All()
								.GroupBy(s=>s.CategoryName)
								.Select(g => new BusinessServiceCategoryModel
								{
									Name = g.Key,
									CountOfServices = g.Count(),
									//CountOfBusinesses = _businessRepository.All().Where(b=>b.BusinessServices.Any(ss=>ss.CategoryName==g.Key)).Count()
									//CountOfBusinesses = services.Where(s=>s.Key.Where(p=>p.))
								}); 
					if (request.Top10)
					{
						query = query.Take(10);
					}
					return new UseCaseResult<IEnumerable<BusinessServiceCategoryModel>>
					{
						ResultCode = "Ok",
						ResultText = "GetBusinessSeviceCategories",
						Data = query.ToList()
					};
				});
			}
			catch (Exception e)
			{
				return new UseCaseResult<IEnumerable<BusinessServiceCategoryModel>>
				{
					ResultCode = "Error",
					ResultText = e.Message
				};
			}

		}
	}

}
