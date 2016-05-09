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
	[EnableCors(origins: "http://localhost:1999", headers: "*", methods: "*")]
	[Authorize]
	public class PostsController : ApiController
	{
		private IPostsService _postService;

		public PostsController(IPostsService discussionService)
		{
			this._postService = discussionService;
		}

		[HttpGet]
		[Route("api/posts/{postId}")]
		public async Task<IHttpActionResult> FindPostsById(Guid postId)
		{
			var result = await _postService.SearchPosts(new PostSearchRequest { PostId = postId });

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpGet]
		[Route("api/posts/search/{search}")]
		public async Task<IHttpActionResult> SearchPosts(string search)
		{
			var result = await _postService.SearchPosts(search);

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
		public async Task<IHttpActionResult> EditDiscussion([FromBody] PostUpdateRequest request, Guid postId)
		{
			var result = await _postService.EditPost(request);

			return ResponseMessage(AwesomeHelper.Content(result));
 
		}

		[HttpPut]
		[Route("api/posts/remove")]
		public async Task<IHttpActionResult> RemoveDiscussion([FromBody] Guid postId)
		{
			var result = await _postService.RemovePost(postId);

			return ResponseMessage(AwesomeHelper.Content(result));
		}
	}
}