using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Awesome.Entities;
using Awesome.Web.Api.Models.Request;

namespace Awesome.Web.Api.Services
{
	public class MarketingService : BaseService, IMarketingService
	{

		public MarketingService(IDbContextFactory<AwesomeEntities> factory) : base(factory)
		{
		}

		public async Task<int> NewExcerptRequest(ExcerptRequest request)
		{
			using (var context = this.Context)
			{
				context.CustomerRequest.Add(new CustomerRequest { BookId = request.BookId, Email = request.Email });

				return await context.SaveChangesAsync();
			}
		}

		public async Task<int> ProcessExcerptRequest(ExcerptRequest request)
		{
			throw new NotImplementedException();
		}
	}
}