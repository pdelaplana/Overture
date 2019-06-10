using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Application.Models
{
    public class StoredFileModel
    {
		public string FileReference { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }
		public string ContentType { get; set; }
		public int FileSize { get; set; }
	}
}
