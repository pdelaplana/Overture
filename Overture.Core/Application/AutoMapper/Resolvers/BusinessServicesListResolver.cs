using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Overture.Core.Domain.Entities;
using Overture.Core.Application.Models;
using Overture.Core.Repositories;

namespace Overture.Core.Application.AutoMapper.Resolvers
{
	public class BusinessServicesListResolver : IValueResolver<BusinessServiceCategory, BusinessServiceCategoryModel, IEnumerable<BusinessServiceModel>>
	{
		private readonly IBusinessServiceRepository _businessServiceRepository;
		private readonly IMapper _mapper;
			
		public BusinessServicesListResolver(IBusinessServiceRepository businessServiceRepository, IMapper mapper)
		{
			_businessServiceRepository = businessServiceRepository;
			_mapper = mapper;
		}

		
		public IEnumerable<BusinessServiceModel> Resolve(BusinessServiceCategory source, BusinessServiceCategoryModel destination, IEnumerable<BusinessServiceModel> destMember, ResolutionContext context)
		{
			return _mapper.Map<IEnumerable<BusinessServiceModel>>(_businessServiceRepository.All().Where(s => s.BusinessServiceCategoryId == source.Id).ToList());
		}
	}
}
