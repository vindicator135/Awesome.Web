using Awesome.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Awesome.Web.Api.Factory
{
	public class AwesomeContextFactory : IDbContextFactory<AwesomeEntities>
	{
		public AwesomeEntities Create()
		{
			return new AwesomeEntities("DefaultConnection");
		}
	}

}