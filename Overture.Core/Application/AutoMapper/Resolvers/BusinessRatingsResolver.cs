using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;


namespace Overture.Core.Application.AutoMapper.Resolvers
{
	public class BusinessRatingsResolver : IValueResolver<Business, BusinessModel, BusinessRatings>
	{
		private readonly IReviewRepository _reviewRepository;

		public BusinessRatingsResolver(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public BusinessRatings Resolve(Business source, BusinessModel destination, BusinessRatings destMember, ResolutionContext context)
		{
			var reviews = _reviewRepository.All().Where(r => r.BusinessId == source.Id).ToList();
			return new BusinessRatings
			{
				TotalReviews = reviews.Count,
				AverageRating = reviews.Count > 0 ? reviews.Average(r=>r.Rating) : 0,
				//JobStatisfaction = reviews.Count > 0 ? reviews.Count(r => r.Satisfied) : 0,
				JobSatisfaction = reviews.Count > 0 ? ((double)reviews.Count(r => r.Satisfied)/reviews.Count)*100 : 0,
				Recommendation = reviews.Count > 0 ? ((double)reviews.Count(r => r.Recommend) / reviews.Count) * 100 : 0,
				OnBudget = reviews.Count > 0 ? ((double)reviews.Count(r => r.OnBudget) / reviews.Count) * 100 : 0,
				OnTime = reviews.Count > 0 ? ((double)reviews.Count(r => r.OnTime) / reviews.Count * 100) : 0,
				Rehire = reviews.Count > 0 ? ((double)reviews.Count(r => r.Rehire) / reviews.Count * 100) : 0,
			};

			
		}
	}
}
