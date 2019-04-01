using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Application.Models
{
    public class DownloadFileModel
    {
		public string ContentType { get; set; }
		public byte[] Contents { get; set; }
    }
}
