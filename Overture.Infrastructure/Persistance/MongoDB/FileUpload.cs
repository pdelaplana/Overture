using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Overture.Infrastructure.Persistance.MongoDB
{
    public class FileUpload
    {
		private readonly MongoDBContext _context;

		public FileUpload(MongoDBContext context)
		{
			_context = context;

		}

		public string Upload(string fileName, byte[] content)
		{
			var fs = new GridFSBucket(_context.Database);
			var id = fs.UploadFromBytes(fileName, content);
			return id.ToString();
			
		}
    }
}
