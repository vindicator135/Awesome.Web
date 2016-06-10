using Awesome.Web.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Awesome.Web.Api.Common;
using System.Threading.Tasks;
using Awesome.Web.Api.Models;
using System.Web.Http.Cors;
using Awesome.Web.Api.Models.Request;
using Newtonsoft.Json;

namespace Awesome.Web.Api.Controllers
{
	[EnableCors(origins: "http://localhost:1999", headers: "*", methods: "*")]
	[Authorize]
	public class MarketingController : ApiController
	{
		private IMarketingService _marketingService;

		public MarketingController(IMarketingService marketingService)
		{
			this._marketingService = marketingService;
		}

		[HttpPost]
		[Route("api/marketing/newexcerptrequest")]
		public async Task<IHttpActionResult> NewExcerptRequest([FromBody] ExcerptRequest request)
		{
			var result = await _marketingService.NewExcerptRequest(request);

			return ResponseMessage(AwesomeHelper.Content(result));
		}
	}
}