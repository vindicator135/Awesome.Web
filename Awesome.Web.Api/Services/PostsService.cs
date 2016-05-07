using Awesome.Entities;
using Awesome.Web.Api.Models;
using Awesome.Web.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public class PostsService : BaseService, IDiscussionsService
	{
		private ICommentsService _commentsService;

		private IRatingsService _ratingsService;

		private ITagsService _tagsService;

		private IUsersService _usersService;

		public PostsService(IDbContextFactory<AwesomeEntities> factory,
			ICommentsService commentsService,
			IRatingsService ratingsService,
			ITagsService tagsService,
			IUsersService usersService) : base(factory)
		{
			this._commentsService = commentsService;

			this._ratingsService = ratingsService;

			this._tagsService = tagsService;

			this._usersService = usersService;
		}

		/// <summary>
		/// Returns the Discussion with the last two comments, Rating, Tags
		/// </summary>
		/// <param name="search"></param>
		/// <returns></returns>
		public async Task<List<PostItem>> SearchDiscussions(string search)
		{
			return await GetDiscussions(search, 1, 5);
		}

		public async Task<List<PostItem>> SearchDiscussions(PostSearchRequest request)
		{
			return await GetDiscussions(request.Search, request.Grouping, request.MaxResults);
		}

		private async Task<List<PostItem>> GetDiscussions(string search, int grouping, int maxResults)
		{
			var result = new List<PostItem>();

			var postQuery = factory.Create().Get<Post>().Select(d => d);

			if (!string.IsNullOrEmpty(search))
			{
				postQuery = postQuery.Where(d => d.Content.Contains(search));
			}

			switch (grouping)
			{
				case 1:
					postQuery = postQuery.OrderByDescending(d => d.LastUpdated);
					break;

				case 2:
					postQuery = postQuery.OrderByDescending(d => d.Ratings.Sum(r => r.Score));
					break;

				default:
					break;
			}

			if (maxResults > 0)
			{
				postQuery = postQuery.Take(maxResults);
			}

			var discussionList = postQuery.ToList();

			foreach (var discussion in discussionList)
			{
				var discussionItem = await GetDiscussionItem(discussion);

				result.Add(discussionItem);
			}

			return result;
		}

		private async Task<PostItem> GetDiscussionItem(Post post)
		{
			var postItem = new PostItem()
			{
				PostId = post.PostId,
				Content = post.Content,
				LastUpdatedOn = post.LastUpdated,
				LastUpdatedBy = _usersService.GetUserName(post.LastUpdatedBy)
			};

			postItem.RatingScore = (int)(await _ratingsService.GetPostAvarageRating(post.PostId));

			List<CommentItem> comments = await _commentsService.GetComments(post.PostId, 3);

			if (comments.FirstOrDefault() != null)
			{
				// Set the Last on to the most recent comment if any
				postItem.LastUpdatedOn = comments.First().LastUpdated;

				comments.ForEach(c =>
				{
					postItem.Comments.Add(c);
				});
			}

			List<TagItem> tags = await _tagsService.GetPostTags(post.PostId);

			if (tags.FirstOrDefault() != null)
			{
				tags.ForEach(t =>
				{
					postItem.Tags.Add(t);
				});
			}
			return postItem;
		}

		public async Task<object> AddPost(PostUpdateRequest request)
		{
			using (var context = factory.Create())
			{
				var post = new Post
				{
					Content = request.Content,
					CreatedBy = request.CreatedBy,
					Created = DateTime.Now,
					Tags = _tagsService.GetTagsById(request.Tags)
				};

				context.Posts.Add(post);

				return await context.SaveChangesAsync();
			}
		}

		public async Task<object> RemoveDiscussion(Guid postId)
		{
			using (var context = factory.Create())
			{
				var post = context.Posts.Find(postId);

				if (post != null)
					context.Posts.Remove(post);

				return await context.SaveChangesAsync();
			}
		}

		public async Task<object> EditDiscussion(PostUpdateRequest request)
		{
			using (var context = factory.Create())
			{
				var post = context.Posts.Include("Tags").FirstOrDefault(d => d.PostId == request.PostId);

				if (post != null)
				{
					post.Content = request.Content;
					post.LastUpdatedBy = request.LastUpdatedBy;
					post.LastUpdated = DateTime.UtcNow;
					post.Tags = _tagsService.GetTagsById(request.Tags);
				}

				return await context.SaveChangesAsync();
			}
		}
	}
}