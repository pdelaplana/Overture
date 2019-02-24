using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Domain.Entities
{
    public interface IEntity
    {
		Guid Id { get; set; }
    }
}
