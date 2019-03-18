using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overture.Core.Services;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;


namespace Overture.Infrastructure.Persistance.MongoDB
{
	public class FileProperties : IFileProperties
	{
		public string FileReference { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }
		public long FileSize { get; set; }
	}
	public class FileStoreService : IFileStoreService
	{
		private readonly MongoDBContext _context;

		public FileStoreService(MongoDBContext context)
		{
			_context = context;
		}


		public bool Delete(string fileReference)
		{
			if (string.IsNullOrEmpty(fileReference)) return false;
			try
			{
				var fs = new GridFSBucket(_context.Database);
				fs.Delete(new ObjectId(fileReference));
				return true;
			}
			catch
			{
				return false;
			}

		}

		public async Task<bool> DeleteAsync(string fileReference)
		{
			if (string.IsNullOrEmpty(fileReference)) return false;
			try
			{
				var fs = new GridFSBucket(_context.Database);
				await fs.DeleteAsync(new ObjectId(fileReference));
				return true;
			}
			catch
			{
				return false;
			}
		}

		
		public byte[] Get(string fileReference)
		{
			throw new NotImplementedException();
		}


		public Task<byte[]> GetAsync(string fileReference)
		{
			throw new NotImplementedException();
		}

		public IFileProperties GetProperties(string fileReference)
		{
			var id = new ObjectId(fileReference);
			FilterDefinition<GridFSFileInfo> filter = Builders<GridFSFileInfo>.Filter.Eq("_id", id);
			var fs = new GridFSBucket(_context.Database);
			var files = fs.Find(filter).ToList();
			if (files != null)
			{
				var fileInfo = files.FirstOrDefault();
				if (fileInfo != null)
				{
					return new FileProperties
					{
						FileReference = fileInfo.Id.ToString(),
						FileName = fileInfo.Filename,
						FileType = Path.GetExtension(fileInfo.Filename)?.Substring(1),
						FileSize = fileInfo.Length
					};
				}
			}
			return null;
		}

		
		
		public IFileProperties Post(string fileName, byte[] content)
		{
			var fs = new GridFSBucket(_context.Database);
			var id = fs.UploadFromBytes(fileName, content);
			if (id != null)
			{
				return GetProperties(id.ToString());
			}
			else
			{
				return null;
			}
		}

		public async Task<IFileProperties> PostAsync(string fileName, byte[] content)
		{
			var fs = new GridFSBucket(_context.Database);
			var id = await fs.UploadFromBytesAsync(fileName, content);
			if (id != null)
			{
				return GetProperties(id.ToString());
			}
			else
			{
				return null;
			}
			
		}
	}
}
