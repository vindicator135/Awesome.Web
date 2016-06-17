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
	public class CommentsController : BaseController
	{
		private ICommentsService _commentsService;

		public CommentsController(ICommentsService commentsService)
		{
			this._commentsService = commentsService;
		}

		[HttpGet]
		[Route("api/comments/top/{count}")]
		public async Task<IHttpActionResult> GetTopComments(int count)
		{
			var result = await _commentsService.SearchComments(new CommentSearchRequest { Top = count});

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpGet]
		[Route("api/comments")]
		public async Task<IHttpActionResult> FindComments([FromUri] CommentSearchRequest request)
		{
			var result = await _commentsService.SearchComments(request);

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpPost]
		[Route("api/comments")]
		public async Task<IHttpActionResult> AddComment([FromBody] CommentUpdateRequest request)
		{
			var result = await _commentsService.AddComment(request);

			return ResponseMessage(AwesomeHelper.Content(result));
		}

		[HttpPut]
		[Route("api/comments/{commentId}")]
		public async Task<IHttpActionResult> EditComment([FromBody] CommentUpdateRequest request, int commentId)
		{
			var result = await _commentsService.EditComment(request);

			return ResponseMessage(AwesomeHelper.Content(result));
 
		}

		[HttpDelete]
		[Route("api/comments/{commentId}")]
		public async Task<IHttpActionResult> DeleteComment(int commentId)
		{
			var result = await _commentsService.DeleteComment(commentId);

			return ResponseMessage(AwesomeHelper.Content(result));
		}
	}
}