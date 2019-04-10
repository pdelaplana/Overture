using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;

namespace Overture.Core.Application.UseCases.Reviews
{
	public class CreateReview : UseCase<ReviewModel>
	{
		public Guid BusinessId { get; set; }
		public string Reviewer { get; set; }
		public DateTime ReviewDate { get; set; }
		public string Content { get; set; }
		public int Rating { get; set; }
		public bool Satisfied { get; set; }
		public bool Recommend { get; set; }
		public bool Rehire { get; set; }
		public bool OnTime { get; set; }
		public bool OnBudget { get; set; }
	}

	public class CreateReviewHandler : IUseCaseHandler<CreateReview, ReviewModel>
	{
		private IReviewRepository _reviewRepository = null;
		private IMapper _mapper = null;

		public CreateReviewHandler(IReviewRepository reviewRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<ReviewModel>> Handle(CreateReview request, CancellationToken cancellationToken)
		{
			try
			{
				return new UseCaseResult<ReviewModel>
				{
					ResultCode = "Ok",
					ResultText = "Create Review",
					Data = _mapper.Map<ReviewModel>(await _reviewRepository.AddAsync(new Review
					{
						BusinessId = request.BusinessId,
						Reviewer = request.Reviewer,
						ReviewDate = request.ReviewDate,
						Content = request.Content,
						Satisfied = request.Satisfied,
						Recommend = request.Recommend,
						Rehire = request.Rehire,
						OnBudget = request.OnBudget,
						OnTime = request.OnTime,
						Rating = request.Rating
						
					}))
				};
			}
			catch (Exception e)
			{
				return new UseCaseResult<ReviewModel>
				{
					ResultCode = "Error",
					ResultText = e.Message,
					Data = null
				};

			}
		}
	}
}
