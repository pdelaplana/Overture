using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Application.AutoMapper.Resolvers;
using Overture.Core.Domain.Entities;

namespace Overture.Core.Application.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			CreateMap<Business, BusinessModel>();
			CreateMap<BusinessService, BusinessServiceModel>();
			CreateMap<BusinessServiceCategory, BusinessServiceCategoryModel>()
				.ForMember(dest => dest.Description, opts => opts.MapFrom<BusinessServiceCategoryDescriptionResolver>())
				.ForMember(dest => dest.CountOfServices, opts => opts.MapFrom<CountOfServicesResolver>());

		}
	}
}
