using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities
{
	public abstract class BaseEntity
	{
		public DateTime Created { get; set; }

		public Guid CreatedBy { get; set; }

		public DateTime? LastUpdated { get; set; }

		public Guid? LastUpdatedBy { get; set; }
	}
}
