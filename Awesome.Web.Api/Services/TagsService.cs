using Awesome.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
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

		public async Task<List<TagItem>> GetPostTags(Guid postId)
		{
			var result = new List<TagItem>();

			var postTags = factory.Create().Posts.Include("Tags").FirstOrDefault(d => d.PostId == postId);

			if (postTags != null && postTags.Tags != null)
			{
				foreach (var t in postTags.Tags.ToList())
				{
					var tagItem = new TagItem
					{
						Description = t.Description
					};

					result.Add(tagItem);
				}
			}
			return result;
		}

		public List<Tag> GetTagsById(List<Guid> tags)
		{
			List<Tag> results = null;

			var matchedTags = factory.Create().Tags.Where(t => tags.Contains(t.TagId)).Select(t => t);

			if (matchedTags.Any())
			{
				results = matchedTags.ToList();
			}

			return results;
		}
	}
}