using Awesome.Entities;
using Awesome.Web.Api.Models;
using Awesome.Web.Api.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface ITagsService : IAwesomeContext
	{
		Task<List<TagItem>> GetPostTags(int postId);

		List<Tag> GetTagsById(List<int> tags);

		Task<List<TagItem>> SearchTags(TagSearchRequest tagSearchRequest);

		Task<int> AddTag(TagUpdateRequest request);

		Task<int> EditTag(TagUpdateRequest request);

		Task<int> DeleteTag(int tagId);
	}
}