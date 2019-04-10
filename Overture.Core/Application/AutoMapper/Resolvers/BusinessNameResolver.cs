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
	public class BusinessNameResolver : IMemberValueResolver<object, object, Guid, string>
	{
		private readonly IBusinessRepository _businessRepository;
		
		public BusinessNameResolver(IBusinessRepository businessRepository)
		{
			_businessRepository = businessRepository;
		}

		public string Resolve(object source, object destination, Guid sourceMember, string destMember, ResolutionContext context)
		{
			return _businessRepository.All().Where(s => s.Id == sourceMember).SingleOrDefault()?.Name;
		}
	}
}
