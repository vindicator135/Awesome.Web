using Awesome.Entities;
using System.Data.Entity.Infrastructure;

namespace Awesome.Web.Api.Services
{
	public abstract class BaseService : IAwesomeContext
	{
		private IDbContextFactory<AwesomeEntities> factory;

		private AwesomeEntities _context;

		public AwesomeEntities Context
		{
			get
			{
				if (_context == null)
					_context = this.factory.Create();
				return _context;
			}
			set
			{
				_context = value;
			}
		}

		public BaseService(IDbContextFactory<AwesomeEntities> factory)
		{
			this.factory = factory;
		}
	}
}