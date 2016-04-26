using Awesome.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Awesome.Web.Api.Services
{
	public class TagsService : ITagsService
	{
		private AwesomeEntities _context;

		public TagsService(AwesomeEntities context)
		{
			this._context = context;		
		}

		public async Task<List<TagItem>> GetDiscussionTags(Guid discussionId)
		{
			var result = new List<TagItem>();

			var discussionTags = _context.Discussions.Include("Tags").FirstOrDefault(d => d.DiscussionId == discussionId);

			if (discussionTags != null && discussionTags.Tags != null)
			{
				foreach(var t in discussionTags.Tags.ToList())
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

			var matchedTags = _context.Tags.Where(t => tags.Contains(t.TagId)).Select(t => t);

			if (matchedTags.Any())
			{
				results = matchedTags.ToList();
			}

			return results;
		}
	}
}