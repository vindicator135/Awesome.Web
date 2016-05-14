using Awesome.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public class TagsService : BaseService, ITagsService
	{
		public TagsService(IDbContextFactory<AwesomeEntities> factory) : base(factory)
		{
		}

		public async Task<List<TagItem>> GetPostTags(int postId)
		{
			var result = new List<TagItem>();

			var postTags = await this.Context.Posts.Include("Tags").FirstOrDefaultAsync(d => d.PostId == postId);

			if (postTags != null && postTags.Tags != null)
			{
				foreach (var t in postTags.Tags.ToList())
				{
					var tagItem = new TagItem
					{
						Name = t.Name
					};

					result.Add(tagItem);
				}
			}
			return result;
		}

		public List<Tag> GetTagsById(List<int> tags)
		{
			List<Tag> results = null;

			var matchedTags = this.Context.Tags.Where(t => tags.Contains(t.TagId)).Select(t => t);

			if (matchedTags.Any())
			{
				results = matchedTags.ToList();
			}

			return results;
		}
	}
}