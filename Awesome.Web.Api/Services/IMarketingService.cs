using Awesome.Web.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface IMarketingService
	{
		Task<int> ProcessExcerptRequest(ExcerptRequest request);
		Task<int> NewExcerptRequest(ExcerptRequest request);
	}
}
