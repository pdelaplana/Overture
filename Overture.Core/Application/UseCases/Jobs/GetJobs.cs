using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;

namespace Overture.Core.Application.UseCases.Jobs
{
    public class GetJobs : UseCase<IEnumerable<JobModel>>
    {
		public string UserId { get; set; }
		public string BusinessId { get; set; }
		public int? Page { get; set; }
		public int? Size { get; set; }
	}

	public class GetJobsHandler : IUseCaseHandler<GetJobs, IEnumerable<JobModel>>
	{

		private readonly IJobRepository _jobRepository = null;
		private readonly IMapper _mapper = null;
		private readonly ILogger _logger = null;

		public GetJobsHandler(IJobRepository jobRepository, IMapper mapper, ILogger<GetJobsHandler> logger)
		{
			_jobRepository = jobRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<UseCaseResult<IEnumerable<JobModel>>> Handle(GetJobs request, CancellationToken cancellationToken)
		{
			try
			{
				return await Task.Run(() =>
				{
					var query = _jobRepository.All();
					if (!string.IsNullOrEmpty(request.UserId))
					{
						query = query.Where(j => j.UserId == request.UserId); 
					}
					else if (!string.IsNullOrEmpty(request.BusinessId))
					{
						query = query.Where(b => b.Quotes.Any(q=>q.QuotedByBusinessId == Guid.Parse(request.BusinessId)));
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

					return UseCaseResult<IEnumerable<JobModel>>.Create(_mapper.Map<IEnumerable<JobModel>>(query.ToList()), resultText: "GetBusinesses");
				});
			}
			catch (Exception e)
			{
				_logger.LogError(e, "");
				return UseCaseResult<IEnumerable<JobModel>>.CreateError(resultText: e.Message);
			}
		}
	}

}
