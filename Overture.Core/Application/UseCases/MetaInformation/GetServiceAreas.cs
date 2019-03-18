using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Overture.Core.Domain.ValueObjects;
using Overture.Core.Services;

namespace Overture.Core.Application.UseCases.MetaInformation
{
    public class GetServiceAreas : IUseCase<IEnumerable<ServiceArea>>
    {
    }

	public class GetServiceAreasHandler : IUseCaseHandler<GetServiceAreas, IEnumerable<ServiceArea>>
	{
		private readonly IMetaInformationService _metaInformationService = null;
		public GetServiceAreasHandler(IMetaInformationService metaInformationService)
		{
			_metaInformationService = metaInformationService;
		}

		public async Task<UseCaseResult<IEnumerable<ServiceArea>>> Handle(GetServiceAreas request, CancellationToken cancellationToken)
		{
			try
			{
				return await Task.Run(() =>
				{
					return UseCaseResult<IEnumerable<ServiceArea>>.Create(_metaInformationService.ServiceAreas, resultText: "Get Service Areas");
				});
			}
			catch (Exception e)
			{
				return UseCaseResult<IEnumerable<ServiceArea>>.CreateError(resultText: e.Message);
			}
		}
	}
}
