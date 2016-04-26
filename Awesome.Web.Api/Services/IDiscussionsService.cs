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

		Task<List<DiscussionItem>> SearchDiscussions(string search);

		Task<List<DiscussionItem>> SearchDiscussions(DiscussionSearchRequest request);

		Task<object> AddDiscussion(DiscussionUpdateRequest request);

		Task<object> RemoveDiscussion(Guid discussionId);

		Task<object> EditDiscussion(DiscussionUpdateRequest request);
	}
}
