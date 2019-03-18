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
	public class BusinessServiceCategoryNameResolver : IMemberValueResolver<object, object, Guid, string>
	{
		private readonly IBusinessServiceCategoryRepository _businessServiceCategoryRepository;

		public BusinessServiceCategoryNameResolver(IBusinessServiceCategoryRepository businessServiceCategoryRepository)
		{
			_businessServiceCategoryRepository = businessServiceCategoryRepository;
		}

		public string Resolve(object source, object destination, Guid sourceMember, string destMember, ResolutionContext context)
		{
			return _businessServiceCategoryRepository.All().Where(s => s.Id == sourceMember).SingleOrDefault()?.Name;
		}
	}
}
