using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Overture.Core.Application.Models;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.ManageServices;
using Overture.Core.Domain.Entities;
using Overture.Core.Repositories;

namespace Overture.Core.Application.UseCases.Administrator
{
    public class InitializeData : IUseCase<InitializeDataModel>
    {
		public bool DeleteDataIfExists { get; set; }
		public bool PopulateBusinessServices { get; set; }
		public bool PoplateContactMethods { get; set; }
    }

	public class InitializeDataHandler : IUseCaseHandler<InitializeData, InitializeDataModel>
	{
		public IBusinessServiceRepository _businessServiceRepository = null;
		public IBusinessServiceCategoryRepository _businessServiceCategoryRepository = null;

		public InitializeDataHandler(IBusinessServiceRepository businessServiceRepository, 
			IBusinessServiceCategoryRepository businessServiceCategoryRepository)
		{
			_businessServiceRepository = businessServiceRepository;
			_businessServiceCategoryRepository = businessServiceCategoryRepository;
		}

		public async Task<UseCaseResult<InitializeDataModel>> Handle(InitializeData request, CancellationToken cancellationToken)
		{
			try
			{
				var counter = 0;

				if (request.PopulateBusinessServices)
				{
					
					var csv = GetEmbeddedResourceAsString("Overture.Core.Domain.InitialData.business_services.csv");
					using (var reader = new CsvReader(new StringReader(csv)))
					{
						while (reader.Read())
						{
							var record = reader.GetRecord<dynamic>();
							await CreateBusinessService(record.Category, record.Name);
							counter++;
						}
					}


					
				}
				return new UseCaseResult<InitializeDataModel>
				{
					ResultCode = "Ok",
					ResultText = "InitializeData",
					Data = new InitializeDataModel
					{
						ServicesCount = counter
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

		private async void CreateBusinessService(string categoryName, string serviceName)
		{
			try
			{
				// fetch guid of service category
				var category = _businessServiceCategoryRepository.All().Where(c => c.Name == categoryName).SingleOrDefault();
				if (category == null)
				{
					category = _businessServiceCategoryRepository.Add(new BusinessServiceCategory { Name = categoryName });
				}


				await _businessServiceRepository.AddAsync(new BusinessService
				{
					Name = serviceName,
					BusinessServiceCategoryId = category.Id
				});

				
			}
			catch (Exception e)
			{
				throw e;
			}

		}
	}
}
