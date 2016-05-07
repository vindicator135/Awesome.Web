using Awesome.Web.Api.Models;
using Awesome.Web.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface IDiscussionsService
	{

		Task<List<PostItem>> SearchDiscussions(string search);

		Task<List<PostItem>> SearchDiscussions(PostSearchRequest request);

		Task<object> AddPost(PostUpdateRequest request);

		Task<object> RemoveDiscussion(Guid discussionId);

		Task<object> EditDiscussion(PostUpdateRequest request);
	}
}
