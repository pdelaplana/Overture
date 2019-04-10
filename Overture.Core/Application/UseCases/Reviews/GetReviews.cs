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

namespace Overture.Core.Application.UseCases.Reviews
{
	public class GetReviews : UseCase<IEnumerable<ReviewModel>>
	{
		public int? Page { get; set; }
		public int? Size { get; set; }

		public Guid BusinessId { get; set; }
		
	}

	public class GetReviewsHandler : IUseCaseHandler<GetReviews, IEnumerable<ReviewModel>>
	{
		private IReviewRepository _reviewRepository = null;
		private IMapper _mapper = null;

		public GetReviewsHandler(IReviewRepository reviewRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<IEnumerable<ReviewModel>>> Handle(GetReviews request, CancellationToken cancellationToken)
		{
			try
			{
				return await Task.Run(() =>
				{
					var query = _reviewRepository.All();
					if (request.BusinessId != Guid.Empty)
					{
						query = query.Where(r=>r.BusinessId == request.BusinessId); // this works
					}
					if (request.Page.HasValue && request.Size.HasValue)
					{
						query = query.Skip(request.Page.Value * request.Size.Value).Take(request.Size.Value);
					}
					else
					{
						// limit results to 500
						query.Take(500);
					}

					return UseCaseResult<IEnumerable<ReviewModel>>.Create(_mapper.Map<IEnumerable<ReviewModel>>(query.ToList()), resultText: "Get Reviews");
				});

			}
			catch (Exception e)
			{
				return new UseCaseResult<IEnumerable<ReviewModel>>
				{
					ResultCode = "Error",
					ResultText = e.Message,
					Data = null
				};

			}
		}
	}
}
