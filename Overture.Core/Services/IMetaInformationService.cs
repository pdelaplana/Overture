using System;
using System.Collections.Generic;
using System.Text;
using Overture.Core.Application;
using Overture.Core.Domain.ValueObjects;

namespace Overture.Core.Services
{
    public interface IMetaInformationService
    {
		MetaInformation Current { get; set; }
		IEnumerable<ServiceArea> ServiceAreas { get;  }
    }
}
