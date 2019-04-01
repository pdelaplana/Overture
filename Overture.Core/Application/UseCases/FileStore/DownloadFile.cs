using Overture.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Overture.Core.Application.Models;

namespace Overture.Core.Application.UseCases.FileStore
{
    public class DownloadFile : UseCase<DownloadFileModel>
	{
		public string FileReference { get; set; }
    }

	public class DownloadFileHandler : IUseCaseHandler<DownloadFile, DownloadFileModel>
	{
		private readonly IFileStoreService _fileStoreService = null;

		public DownloadFileHandler(IFileStoreService fileStoreService)
		{
			_fileStoreService = fileStoreService;
		}

		public async Task<UseCaseResult<DownloadFileModel>> Handle(DownloadFile request, CancellationToken cancellationToken)
		{
			try
			{
				if (!string.IsNullOrEmpty(request.FileReference))
				{
					var props = _fileStoreService.GetProperties(request.FileReference);
					var model = new DownloadFileModel
					{
						ContentType = props.ContentType,
						Contents = await _fileStoreService.GetAsync(request.FileReference)
					};
					return UseCaseResult<DownloadFileModel>.Create(model);
				}
				else
				{
					return UseCaseResult<DownloadFileModel>.CreateError(resultText:"File Reference not found");
				}
			}
			catch (Exception e)
			{
				return UseCaseResult<DownloadFileModel>.CreateError(resultText: e.Message);
			}
		}
	}

}
