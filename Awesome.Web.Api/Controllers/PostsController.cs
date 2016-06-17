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
	public class PostsController : BaseController
	{
		private IPostsService _postService;

		public PostsController(IPostsService discussionService)
		{
			this._postService = discussionService;
		}

		[HttpGet]
		[Route("api/posts")]
		public async Task<IHttpActionResult> SearchPosts([FromUri] PostSearchRequest request)
		{
			var result = await _postService.SearchPosts(request);

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpGet]
		[Route("api/posts/top/{top}")]
		public async Task<IHttpActionResult> GetRecentPosts(int top)
		{
			var result = await _postService.SearchPosts(new PostSearchRequest { Top = top });

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpGet]
		[Route("api/posts/{postId}/details")]
		public async Task<IHttpActionResult> FindPostsById(int postId)
		{
			var result = await _postService.GetPostDetails(postId);

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		

		[HttpPost]
		[Route("api/posts")]
		public async Task<IHttpActionResult> AddPost([FromBody] PostUpdateRequest request)
		{
			var result = await _postService.AddPost(request);

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpPut]
		[Route("api/posts/{postId}")]
		public async Task<IHttpActionResult> EditPost([FromBody] PostUpdateRequest request, int postId)
		{
			var result = await _postService.EditPost(request);

			return ResponseMessage(AwesomeHelper.Content(result));
 
		}

		[HttpDelete]
		[Route("api/posts/{postId}")]
		public async Task<IHttpActionResult> RemovePost(int postId)
		{
			var result = await _postService.RemovePost(postId);

			return ResponseMessage(AwesomeHelper.Content(result));
		}
	}
}