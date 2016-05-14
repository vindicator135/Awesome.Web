using Awesome.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface ITagsService : IAwesomeContext
	{
		Task<List<TagItem>> GetPostTags(int postId);

		List<Tag> GetTagsById(List<int> tags);
	}
}
