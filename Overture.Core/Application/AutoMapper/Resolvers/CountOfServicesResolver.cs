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
	public class CountOfServicesResolver : IValueResolver<BusinessServiceCategory, BusinessServiceCategoryModel, int>
	{
		private readonly IBusinessServiceRepository _businessServiceRepository;

		public CountOfServicesResolver(IBusinessServiceRepository businessServiceRepository)
		{
			_businessServiceRepository = businessServiceRepository;
		}

		public int Resolve(BusinessServiceCategory source, BusinessServiceCategoryModel destination, int destMember, ResolutionContext context)
		{
			return _businessServiceRepository.All().Where(s => s.CategoryName == source.Name).Count();
		}
	}
}
