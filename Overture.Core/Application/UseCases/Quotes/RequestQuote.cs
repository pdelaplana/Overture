using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Domain.Entities;
using Overture.Core.Domain.ValueObjects;
using Overture.Core.Repositories;
using Overture.Core.Services;

namespace Overture.Core.Application.UseCases.Quotes
{
    public class RequestQuote : UseCase<JobModel>
    {
		public string Name { get; set; }
		public string Email { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime RequiredDate { get; set; }
		public Guid BusinessId { get; set; }
	}

	public class RequestQuoteHandler : IUseCaseHandler<RequestQuote, JobModel>
	{
		private readonly IJobRepository _jobRepository = null;
		private readonly IUserService _userService = null;
		private readonly IMapper _mapper = null;

		public RequestQuoteHandler(IJobRepository jobRepository, IUserService userService, IMapper mapper)
		{
			_jobRepository = jobRepository;
			_userService = userService;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<JobModel>> Handle(RequestQuote request, CancellationToken cancellationToken)
		{
			try
			{
				// fetch user id
				var user = await _userService.GetUserByEmailAsync(request.Email);
				if (user == null)
				{
					user = new OvertureUser
					{
						Name = request.Name,
						AccountType = AccountType.Personal,
						Email = request.Email,
					};
					user = await _userService.CreateUserAsync(user, "TODO:ChangeThisToARandomPassword");
				}

				
				return new UseCaseResult<JobModel>
				{
					ResultCode = "Ok",
					ResultText = "Create Job",
					Data = _mapper.Map<JobModel>(await _jobRepository.AddAsync(new Job
					{
						UserId = user.UserId,
						Title = request.Title,
						Description = request.Description,
						RequiredDate = request.RequiredDate,
						Quotes = new List<Quote>()
						{
							new Quote() { QuotedByBusinessId = request.BusinessId }
						}
					}))
				};
			}
			catch (Exception e)
			{
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

