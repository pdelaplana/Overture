using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Repositories;
using Overture.Core.Domain.Entities;
using Overture.Core.Domain.ValueObjects;

namespace Overture.Core.Application.UseCases.ManageBusinesses
{
    public class UpdateBusiness : UseCase<BusinessModel>
    {
		public Guid Id { get; set; } 
		public string Name { get; set; }
		public string Owner { get; set; }
		public string Description { get; set; }
		public string Tagline { get; set; }
		public FileAttachment Picture { get; set; }
		public bool IsTrading { get; set; }
		public Address Address { get; set; }
		public IEnumerable<BusinessService> BusinessServices { get; set; }
		public IEnumerable<ContactMethod> ContactMethods { get; set; }
		public IEnumerable<ServiceArea> ServiceAreas { get; set; }
		public IEnumerable<FileAttachment> FileAttachments { get; set; }
    }

	public class UpdateBusinessHandler : IUseCaseHandler<UpdateBusiness, BusinessModel>
	{
		private IBusinessRepository _repository = null;
		private IBusinessServiceRepository _businessServiceRepository = null;
		private IMapper _mapper = null;

		public UpdateBusinessHandler(IBusinessRepository repository, 
			IBusinessServiceRepository businessServicesRepository, 
			IMapper mapper)
		{
			_repository = repository;
			_businessServiceRepository = businessServicesRepository;
			_mapper = mapper;
		}
		public async Task<UseCaseResult<BusinessModel>> Handle(UpdateBusiness request, CancellationToken cancellationToken)
		{
			try
			{
				var business = _repository.All().Where(b => b.Id == request.Id).SingleOrDefault();
				if (business == null)
				{
					business = new Business();
					business.UserId = request.Context.UserId;
				}
				business.Name = request.Name;
				//business.AltReference = request.Name.ToLower()..Replace(" ", "-");
				business.AltReference = Regex.Replace(request.Name.ToLower(), @"[^A-Za-z0-9_\.~]+", "-");
				business.Owner = request.Owner;
				business.Tagline = request.Tagline;
				business.Description = request.Description;
				business.Picture = request.Picture;
				business.IsTrading = request.IsTrading;
				business.Address = request.Address;
				business.ServiceAreas = request.ServiceAreas;
				business.BusinessServices = request.BusinessServices;
				business.ContactMethods = request.ContactMethods;
				business.FileAttachments = request.FileAttachments;

				if (business.Id == Guid.Empty)
				{
					await _repository.AddAsync(business);
					return UseCaseResult<BusinessModel>.Create(_mapper.Map<BusinessModel>(business), resultText: "Update Business");
				}
				else
				{
					await _repository.UpdateAsync(business);
					return UseCaseResult<BusinessModel>.Create(_mapper.Map<BusinessModel>(business), resultText: "Update Business");
				}

			}
			catch (Exception e)
			{
				return UseCaseResult<BusinessModel>.CreateError(resultText: e.Message);
			}
			
		}
	}
}
