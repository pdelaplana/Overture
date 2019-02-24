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
	public class GetBusinessServiceCategoriesList : IUseCase<IEnumerable<BusinessServiceCategoryModel>>
	{
		public bool Top10 { get; set; }
	}
	public class GetBusinessServicesListHandler : IUseCaseHandler<GetBusinessServiceCategoriesList, IEnumerable<BusinessServiceCategoryModel>>
	{
		private IBusinessServiceCategoryRepository _repository = null;
		private IMapper _mapper = null;

		public GetBusinessServicesListHandler(IBusinessServiceCategoryRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<UseCaseResult<IEnumerable<BusinessServiceCategoryModel>>> Handle(GetBusinessServiceCategoriesList request, CancellationToken cancellationToken)
		{
			try
			{
				return await Task.Run(() =>
				{
					var query = _repository.All();
					if (request.Top10)
					{
						query = query.Take(10);
					}
					return new UseCaseResult<IEnumerable<BusinessServiceCategoryModel>>
					{
						ResultCode = "Ok",
						ResultText = "GetBusinessSeviceCategories",
						Data = _mapper.Map<List<BusinessServiceCategoryModel>>(query.ToList())
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
