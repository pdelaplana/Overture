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

namespace Overture.Core.Application.UseCases.Jobs
{
    public class GetJob : UseCase<JobModel>
    {
		public Guid Id { get; set; }
	}

	public class GetJobHandler : IUseCaseHandler<GetJob, JobModel>
	{

		private readonly IJobRepository _jobRepository = null;
		private readonly IMapper _mapper = null;

		public GetJobHandler(IJobRepository jobRepository, IMapper mapper)
		{
			_jobRepository = jobRepository;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<JobModel>> Handle(GetJob request, CancellationToken cancellationToken)
		{
			try
			{
				return await Task.Run(() =>
				{
					var job= _jobRepository.All().Where(j => j.Id == request.Id).SingleOrDefault();

					if (job != null)
					{
						return UseCaseResult<JobModel>.Create(_mapper.Map<JobModel>(job), resultText: "Get Business");
					}

					// else
					throw new Exception("Record not found.");

				});
			}
			catch (Exception e)
			{
				return UseCaseResult<JobModel>.CreateError(resultText: e.Message);
			}
		}
	}

}
