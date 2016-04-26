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

namespace Awesome.Web.Api.Controllers
{
	[EnableCors(origins: "http://localhost:63290", headers: "*", methods: "*")]
	public class DiscussionsController : ApiController
	{
		private IDiscussionsService _discussionService;

		public DiscussionsController(IDiscussionsService discussionService)
		{
			this._discussionService = discussionService;
		}

		[HttpGet]
		[Route("api/discussion/{discussionId}")]
		public async Task<IHttpActionResult> FindDiscussionById(Guid discussionId)
		{
			var result = await _discussionService.SearchDiscussions(new DiscussionSearchRequest { DiscussionId = discussionId });

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpGet]
		[Route("api/discussion/search/{search}")]
		public async Task<IHttpActionResult> SearchDiscussions(string search)
		{
			var result = await _discussionService.SearchDiscussions(search);

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpPost]
		[Route("api/discussion")]
		public async Task<IHttpActionResult> AddDiscussion([FromBody] DiscussionUpdateRequest request)
		{
			var result = await _discussionService.AddDiscussion(request);

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpPut]
		[Route("api/discussion/{discussionId}")]
		public async Task<IHttpActionResult> EditDiscussion([FromBody] DiscussionUpdateRequest request, Guid discussionId)
		{
			var result = await _discussionService.EditDiscussion(request);

			return ResponseMessage(AwesomeHelper.Content(result));
 
		}

		[HttpPut]
		[Route("api/discussion/remove")]
		public async Task<IHttpActionResult> RemoveDiscussion([FromBody] Guid discussionId)
		{
			var result = await _discussionService.RemoveDiscussion(discussionId);

			return ResponseMessage(AwesomeHelper.Content(result));
		}
	}
}