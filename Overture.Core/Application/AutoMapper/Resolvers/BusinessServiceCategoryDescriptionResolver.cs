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
	public class BusinessServiceCategoryDescriptionResolver : IValueResolver<BusinessServiceCategory, BusinessServiceCategoryModel, string>
	{
		private readonly IBusinessServiceRepository _businessServiceRepository;

		public BusinessServiceCategoryDescriptionResolver(IBusinessServiceRepository businessServiceRepository)
		{
			_businessServiceRepository = businessServiceRepository;
		}

		public string Resolve(BusinessServiceCategory source, BusinessServiceCategoryModel destination, string destMember, ResolutionContext context)
		{
			var services = _businessServiceRepository.All().Where(s => s.CategoryName == source.Name).Take(3).Select(s=>s.Name).ToList();
			return $"{string.Join(", ", services) }..."; 		
		}

	
	}
}
