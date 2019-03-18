using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Overture.Core.Application.UseCases;
using Overture.Core.Application.UseCases.FileStore;
using Overture.Core.Application.Models;


namespace Overture.Web.API.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : OvertureController
    {
		private readonly IHostingEnvironment _hostingEnvironment;
		
		public FileController(IHostingEnvironment hostingEnvironment)
		{
			_hostingEnvironment = hostingEnvironment;
			
		}

		[HttpPost, DisableRequestSizeLimit]
		[Authorize]
		public async Task<ActionResult<UseCaseResult<FileAttachmentModel>>> UploadFile(IFormFile file)
		{
			
			try
			{
				if (file.Length > 0)
				{
					using (var ms = new MemoryStream())
					{
						file.CopyTo(ms);
						return Ok(await UseCase.Execute(new UploadFile { FileName = file.FileName, Contents = ms.ToArray() }));

					}
				}
				else
				{
					return StatusCode(StatusCodes.Status204NoContent, "Empty file");
				}
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Upload Failed: " + ex.Message);
			}
		}
	}
}