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
    public class UploadFile : UseCase<FileAttachmentModel>
    {
		public string FileName { get; set; }
		public string ContentType { get; set; }
		public byte[] Contents { get; set; }
    }

	public class UploadFileHandler : IUseCaseHandler<UploadFile, FileAttachmentModel>
	{
		private readonly IFileStoreService _fileStoreService = null;
		private readonly IMapper _mapper = null;

		public UploadFileHandler(IFileStoreService fileStoreService, IMapper mapper)
		{
			_fileStoreService = fileStoreService;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<FileAttachmentModel>> Handle(UploadFile request, CancellationToken cancellationToken)
		{
			try
			{
				if (!string.IsNullOrEmpty(request.FileName))
				{
					if (request.Contents.Length > 0)
					{
						return UseCaseResult<FileAttachmentModel>.Create( _mapper.Map<IFileProperties, FileAttachmentModel>(await _fileStoreService.PostAsync(request.FileName, request.Contents, request.ContentType)));
					}
					else
					{
						return UseCaseResult<FileAttachmentModel>.CreateError(resultText: "File Contents are empty");
					}
				}
				else
				{
					return UseCaseResult<FileAttachmentModel>.CreateError(resultText: "No File Name Specified");
				}
			}
			catch (Exception e)
			{
				return UseCaseResult<FileAttachmentModel>.CreateError(resultText: e.Message);
			}
		}
	}
}
