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
    public class DeleteFile : UseCase<bool>
    {
		public string FileReference { get; set; }
    }

	public class DeleteFileHandler : IUseCaseHandler<DeleteFile, bool>
	{
		private readonly IFileStoreService _fileStoreService = null;
		private readonly IMapper _mapper = null;

		public DeleteFileHandler(IFileStoreService fileStoreService, IMapper mapper)
		{
			_fileStoreService = fileStoreService;
			_mapper = mapper;
		}

		public async Task<UseCaseResult<bool>> Handle(DeleteFile request, CancellationToken cancellationToken)
		{
			try
			{
				if (!string.IsNullOrEmpty(request.FileReference))
				{
					return UseCaseResult<bool>.Create(await _fileStoreService.DeleteAsync(request.FileReference));
				}
				else
				{
					return UseCaseResult<bool>.CreateError(resultText: "File Reference not provided");
				}
			}
			catch (Exception e)
			{
				return UseCaseResult<bool>.CreateError(resultText: e.Message);
			}
		}
	}
}
