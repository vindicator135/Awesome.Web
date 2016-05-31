using Awesome.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awesome.Web.Api.Models.Request;

namespace Awesome.Web.Api.Services
{
	public interface ICommentsService : IAwesomeContext
	{
		
		Task<List<CommentItem>> SearchComments(CommentSearchRequest request);
		Task<int> AddComment(CommentUpdateRequest request);
		Task<int> EditComment(CommentUpdateRequest request);
		Task<int> DeleteComment(int commentId);
	}
}
