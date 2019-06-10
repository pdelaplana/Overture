using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Overture.Core.Application.Models;
using Overture.Core.Domain.ValueObjects;
using Overture.Core.Services;

namespace Overture.Core.Application.UseCases.FileStore
{
    public class UploadFile : UseCase<StoredFileModel>
    {
		public string FileName { get; set; }
		public string ContentType { get; set; }
		public byte[] Contents { get; set; }
    }

	public class UploadFileHandler : IUseCaseHandler<UploadFile, StoredFileModel>
	{
		private readonly IFileStoreService _fileStoreService = null;
		private readonly IMapper _mapper = null;

		public UploadFileHandler(IFileStoreService fileStoreService, IMapper mapper)
		{
			_fileStoreService = fileStoreService;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<StoredFileModel>> Handle(UploadFile request, CancellationToken cancellationToken)
		{
			try
			{
				if (!string.IsNullOrEmpty(request.FileName))
				{
					if (request.Contents.Length > 0)
					{
						return UseCaseResult<StoredFileModel>.Create( _mapper.Map<IFileProperties, StoredFileModel>(await _fileStoreService.PostAsync(request.FileName, request.Contents, request.ContentType)));
					}
					else
					{
						return UseCaseResult<StoredFileModel>.CreateError(resultText: "File Contents are empty");
					}
				}
				else
				{
					return UseCaseResult<StoredFileModel>.CreateError(resultText: "No File Name Specified");
				}
			}
			catch (Exception e)
			{
				return UseCaseResult<StoredFileModel>.CreateError(resultText: e.Message);
			}
		}
	}
}
