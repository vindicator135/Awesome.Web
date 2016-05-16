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
	public class TagsController : ApiController
	{
		private ITagsService _tagService;

		public TagsController(ITagsService tagService)
		{
			this._tagService = tagService;
		}

		[HttpGet]
		[Route("api/tags/{query}")]
		public async Task<IHttpActionResult> SearchTags(string query)
		{
			var result = await _tagService.SearchTags(new TagSearchRequest { Search = query });

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpGet]
		[Route("api/tags/top/{top}")]
		public async Task<IHttpActionResult> GetRecentTags(int top)
		{
			var result = await _tagService.SearchTags(new TagSearchRequest { Top = top });

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpPost]
		[Route("api/tags")]
		public async Task<IHttpActionResult> AddTag([FromBody] TagUpdateRequest request)
		{
			var result = await _tagService.AddTag(request);

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpPut]
		[Route("api/tags/{tagId}")]
		public async Task<IHttpActionResult> EditPost([FromBody] TagUpdateRequest request, int tagId)
		{
			var result = await _tagService.EditTag(request);

			return ResponseMessage(AwesomeHelper.Content(result));
 
		}

		[HttpDelete]
		[Route("api/tags/{tagId}")]
		public async Task<IHttpActionResult> DeleteTag(int tagId)
		{
			var result = await _tagService.DeleteTag(tagId);

			return ResponseMessage(AwesomeHelper.Content(result));
		}
	}
}