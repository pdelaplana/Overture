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
using Overture.Core.Services;

namespace Overture.Core.Application.UseCases.Jobs
{
    public class UpdateJob : UseCase<JobModel>
    {
		public Guid Id { get; set;  }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime RequiredDate { get; set; } 
	}

	public class UpdateJobHandler : IUseCaseHandler<UpdateJob, JobModel>
	{
		private readonly IJobRepository _jobRepository = null;
		private readonly IUserService _userService = null;
		private readonly IMapper _mapper = null;
		private readonly ILogger _logger = null;

		public UpdateJobHandler(IJobRepository jobRepository, IUserService userService, IMapper mapper, ILogger<UpdateJobHandler> logger)
		{
			_jobRepository = jobRepository;
			_userService = userService;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<UseCaseResult<JobModel>> Handle(UpdateJob request, CancellationToken cancellationToken)
		{
			try
			{
				var job = this._jobRepository.All().Where(j => j.Id == request.Id).SingleOrDefault();
				if (job != null)
				{
					job.Title = request.Title;
					job.Description = request.Description;

					return new UseCaseResult<JobModel>
					{
						ResultCode = "Ok",
						ResultText = "Update Job",
						Data = _mapper.Map<JobModel>(await _jobRepository.UpdateAsync(job))
					};
				}
				else
				{
					throw new Exception("Record not found");
				}
				
				
			}
			catch (Exception e)
			{
				_logger.LogError(e, "");
				return new UseCaseResult<JobModel>
				{
					ResultCode = "Error",
					ResultText = e.Message,
					Data = null
				};
			};
		}
		
	}
}
