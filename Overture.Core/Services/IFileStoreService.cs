using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Overture.Core.Services
{
	public interface IFileProperties
	{
		string FileReference { get; set;  }
		string FileName { get; set; }
		string FileType { get; set; }
		string ContentType { get; set; }
		long FileSize { get; set; }
	}
	public interface IFileReference
	{
		string Reference { get; set; }
	}
	
    public interface IFileStoreService
    {
		IFileProperties GetProperties(string fileReference);
		byte[] Get(string fileReference);
		Task<byte[]> GetAsync(string fileReference);
		IFileProperties Post(string fileName, byte[] content, string contentType);
		Task<IFileProperties> PostAsync(string fileName, byte[] content, string contentType);
		bool Delete(string fileReference);
		Task<bool> DeleteAsync(string fileReference);

	}
}
