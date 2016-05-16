using Awesome.Entities;
using Awesome.Web.Api.Models;
using Awesome.Web.Api.Models.Request;
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

		public async Task<List<TagItem>> SearchTags(TagSearchRequest request)
		{
			var tagsQuery = this.Context.Tags.Select(t => t);

			if (!string.IsNullOrEmpty(request.Search))
			{
				tagsQuery = tagsQuery.Where(d => d.Name.Contains(request.Search) || d.Description.Contains(request.Search));
			}

			tagsQuery = tagsQuery.OrderBy(t => t.Name);

			if (request.Top > 0)
			{
				tagsQuery = tagsQuery.Take(request.Top);
			}

			var result = tagsQuery.Select(t => new TagItem
			{
				TagId = t.TagId,
				Name = t.Name,
				Description = t.Description
			}).ToList();

			return result;
		}

		public async Task<int> AddTag(TagUpdateRequest request)
		{
			using (var context = this.Context)
			{
				var user = context.Users.Where(x => x.UserName == request.CreatedBy).First();

				context.Tags.Add(new Tag { Name = request.Name, Description = request.Description, CreatedBy = user, Created = DateTime.UtcNow });

				return await context.SaveChangesAsync();
			}
		}

		public async Task<int> DeleteTag(int tagId)
		{
			using (var context = this.Context)
			{
				var result = 0;

				var tag = context.Tags.FirstOrDefault(t => t.TagId == tagId);

				if (tag != null)
				{
					context.Tags.Remove(tag);

					result = await context.SaveChangesAsync();
				}

				return result;
			}
		}

		public async Task<int> EditTag(TagUpdateRequest request)
		{
			using (var context = this.Context)
			{
				var user = context.Users.Where(x => x.UserName == request.LastUpdatedBy).First();

				var tag = context.Tags.First(t => t.TagId == request.TagId);

				tag.Name = request.Name;
				tag.Description = request.Description;
				tag.LastUpdated = DateTime.UtcNow;
				tag.LastUpdatedBy = user;

				return await context.SaveChangesAsync();
			}
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