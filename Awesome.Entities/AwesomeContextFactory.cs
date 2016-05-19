using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Entities
{
	public class AwesomeContextFactory : IDbContextFactory<AwesomeEntities>
	{
		public AwesomeEntities Create()
		{
			return new AwesomeEntities("DefaultConnection");
		}
	}
}
