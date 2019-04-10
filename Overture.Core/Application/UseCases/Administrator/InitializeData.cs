using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Overture.Core.Application;
using Overture.Core.Application.Models;
using Overture.Core.Domain.Entities;
using Overture.Core.Domain.ValueObjects;
using Overture.Core.Repositories;
using Overture.Core.Services;


namespace Overture.Core.Application.UseCases.Administrator
{
    public class InitializeData : UseCase<InitializeDataModel>
    {
		public bool DeleteDataIfExists { get; set; }
		public bool IntializeMetaInformation { get; set; }
		public bool PopulateBusinessServices { get; set; }
		public bool PopulateSampleBusinesses { get; set; }
		public bool PoplateContactMethods { get; set; }
		
	}

	public class InitializeDataHandler : IUseCaseHandler<InitializeData, InitializeDataModel>
	{
		public IBusinessRepository _businessRepository = null;
		public IBusinessServiceRepository _businessServiceRepository = null;
		public IBusinessServiceCategoryRepository _businessServiceCategoryRepository = null;
		public IMetaInformationService _metaInformationService = null;

		public InitializeDataHandler(
			IBusinessRepository businessRepository,
			IBusinessServiceRepository businessServiceRepository, 
			IBusinessServiceCategoryRepository businessServiceCategoryRepository,
			IMetaInformationService metaInformationService)
		{
			_businessRepository = businessRepository;
			_businessServiceRepository = businessServiceRepository;
			_businessServiceCategoryRepository = businessServiceCategoryRepository;
			_metaInformationService = metaInformationService;
		}

		public async Task<UseCaseResult<InitializeDataModel>> Handle(InitializeData request, CancellationToken cancellationToken)
		{
			try
			{
				InitializeMetaInformation(request);
				return new UseCaseResult<InitializeDataModel>
				{
					ResultCode = "Ok",
					ResultText = "InitializeData",
					Data = new InitializeDataModel
					{
						ContactMethodsCount = _metaInformationService.Current.ContactMethodTypes.Count(),
						ServiceCategoriesCount = _metaInformationService.Current.ServiceCategories.Count(),
						ServiceAreasCount = _metaInformationService.Current.ServiceAreas.Count(),
						ServicesCount = await PopulateBusinessServices(request),
						SampleBusinessesCount = await PopulateSampleBusinesses(request)
					}
				};
			}
			catch (Exception e)
			{
				return new UseCaseResult<InitializeDataModel>
				{
					ResultCode = "Error",
					ResultText = e.Message
				};
			}
			
			
		}

		private string GetEmbeddedResourceAsString(string resourceName)
		{
			var assembly = Assembly.GetExecutingAssembly();

			var names = assembly.GetManifestResourceNames();

			string result;
			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			using (StreamReader reader = new StreamReader(stream))
			{
				result = reader.ReadToEnd();
			}
			return result;
		}

		private void InitializeMetaInformation(InitializeData request)
		{
			var counter = 0;
			if (request.IntializeMetaInformation)
			{
				var serviceAreas = new List<ServiceArea>();
				using (var reader = new CsvReader(new StringReader(GetEmbeddedResourceAsString("Overture.Core.Domain.InitialData.service_areas.csv"))))
				{
					while (reader.Read())
					{
						var record = reader.GetRecord<dynamic>();
						serviceAreas.Add(new ServiceArea
						{
							Name = record.Name
						});
						counter++;
					}
				};

				counter = 0;
				var serviceCategories = new List<ServiceCategory>();
				using (var reader = new CsvReader(new StringReader(GetEmbeddedResourceAsString("Overture.Core.Domain.InitialData.service_categories.csv"))))
				{
					while (reader.Read())
					{
						var record = reader.GetRecord<dynamic>();
						serviceCategories.Add(new ServiceCategory
						{
							Name = record.Name
						});
						counter++;
					}
				}


				var contactMethods = new List<string>();
				using (var reader = new CsvReader(new StringReader(GetEmbeddedResourceAsString("Overture.Core.Domain.InitialData.contact_methods.csv"))))
				{
					while (reader.Read())
					{
						var record = reader.GetRecord<dynamic>();
						contactMethods.Add(record.Name);
						counter++;
					}
				}

				_metaInformationService.Current = new Application.MetaInformation
				{
					ServiceAreas = serviceAreas,
					ServiceCategories = serviceCategories,
					ContactMethodTypes = contactMethods.ToArray()
				};

			}

		}

		private async Task<int> PopulateBusinessServices(InitializeData request)
		{
			var counter = 0;
			if (request.PopulateBusinessServices)
			{
				if (request.DeleteDataIfExists)
				{
					await _businessServiceRepository.DeleteAllAsync();
				}
				var csv = GetEmbeddedResourceAsString("Overture.Core.Domain.InitialData.business_services.csv");
				using (var reader = new CsvReader(new StringReader(csv)))
				{
					while (reader.Read())
					{
						var record = reader.GetRecord<dynamic>();
						await _businessServiceRepository.AddAsync(new BusinessService
						{
							Name = record.Name,
							CategoryName = record.Category
						});
						counter++;
					}
				}
			}
			return counter;
		}

		private async Task<int> PopulateSampleBusinesses(InitializeData request)
		{
			var counter = 0;
			if (request.PopulateSampleBusinesses)
			{
				var csv = GetEmbeddedResourceAsString("Overture.Core.Domain.InitialData.sample_businesses.csv");
				using (var reader = new CsvReader(new StringReader(csv)))
				{
					while (reader.Read())
					{
						var record = reader.GetRecord<dynamic>();
						var services = new List<BusinessService>();
						foreach (var service in ((string[])record.BusinessServices.Split("|")).ToList())
						{
							var found = _businessServiceRepository.All().Where(s => s.Name == service).FirstOrDefault();
							if (found != null)
							{
								services.Add(found);
							}
						}
						var areas = new List<ServiceArea>();
						foreach (var area in ((string[])record.ServiceAreas.Split("|")).ToList())
						{
							if (!string.IsNullOrEmpty(area))
							{
								areas.Add(new ServiceArea { Name = area });
							}
						}

						string name = record.Name.ToString().TrimEnd(Environment.NewLine.ToCharArray());
						await _businessRepository.AddAsync(new Business
						{
							Name = name,
							//AltReference = name.ToLower().Replace(" ", "-"),
							AltReference = Regex.Replace(name.ToLower(), @"[^A-Za-z0-9_\.~]+", "-"),
							Owner = record.Owner,
							Tagline = record.Tagline,
							Description = record.Description,
							IsTrading = true,
							Address = new Address(),
							ContactMethods = new List<ContactMethod>(),
							BusinessServices = services,
							ServiceAreas = areas,
							FileAttachments = new List<FileAttachment>()
						});
						counter++;
					}
				}
			}
			return counter;
		}
	}
}
