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
	public class PostsService : BaseService, IPostsService
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
			this._commentsService.Context = this.Context;
			
			this._ratingsService = ratingsService;
			this._ratingsService.Context = this.Context;

			this._tagsService = tagsService;
			this._tagsService.Context = this.Context;

			this._usersService = usersService;
			this._usersService.Context = this.Context;
		}

		public async Task<List<PostItem>> SearchPosts(PostSearchRequest request)
		{
			var result = new List<PostItem>();

			var postQuery = this.Context.Posts.Include("Tags").Select(p => p);

			if (!string.IsNullOrEmpty(request.Search))
			{
				postQuery = postQuery.Where(d => d.Content.Contains(request.Search) || d.Title.Contains(request.Search) || d.SubContent.Contains(request.Search));
			}

			if (!string.IsNullOrEmpty(request.Tags))
			{
				var tagList = request.Tags
					.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
					.Select(t => Convert.ToInt32(t)).ToList();

				postQuery = postQuery.Where(p => p.Tags.Any(t => tagList.Contains(t.TagId)));
			}

			switch (request.Grouping)
			{
				case 2:
					postQuery = postQuery.OrderByDescending(d => d.Ratings.Sum(r => r.Score));
					break;
				case 1:
				default:
					postQuery = postQuery.OrderByDescending(d => d.LastUpdated);
					break;
			}

			if (request.Top > 0)
			{
				postQuery = postQuery.Take(request.Top);
			}

			var postList = postQuery.ToList();

			

			foreach (var post in postList)
			{
				var postItem = new PostItem
				{
					SubContent = post.SubContent,
					Title = post.Title,
					SubTitle = post.SubTitle,
					PostId = post.PostId,
					TitleText = post.TitleText,
					PostAvatarUrl = post.PostAvatarUrl,
					Tags = post.Tags.Select(t => new TagItem { Name = t.Name, TagId = t.TagId  }).ToList()
				};

				result.Add(postItem);
			}

			return result;
		}

		public async Task<object> AddPost(PostUpdateRequest request)
		{
			using (var context = this.Context)
			{
				var user = context.Users.Where(x => x.UserName == request.CreatedBy).FirstOrDefault();

				var post = new Post
				{
					Content = request.Content,
					SubTitle = request.SubTitle,
					Title = request.Title,
					SubContent = request.SubContent,
					TitleText = request.TitleText,
					PreContent = request.PreContent,
					PostAvatarUrl = request.PostAvatarUrl,
					CreatedBy = user,
					Created = DateTime.UtcNow,
					LastUpdated = DateTime.UtcNow,
					Tags = _tagsService.GetTagsById(request.Tags)
				};

				context.Posts.Add(post);

				return await context.SaveChangesAsync();
			}
		}

		public async Task<object> RemovePost(int postId)
		{
			using (var context = this.Context)
			{
				var post = context.Posts.Find(postId);

				if (post != null)
					context.Posts.Remove(post);

				return await context.SaveChangesAsync();
			}
		}

		public async Task<object> EditPost(PostUpdateRequest request)
		{
			using (var context = this.Context)
			{
				var post = context.Posts.Include("Tags").FirstOrDefault(d => d.PostId == request.PostId);

				var user = context.Users.FirstOrDefault(x => x.UserName.Equals(request.LastUpdatedBy, StringComparison.InvariantCultureIgnoreCase));

				if (post != null)
				{
					post.Title = request.Title;
					post.SubTitle = request.SubTitle;
					post.TitleText = request.TitleText;
					post.PreContent = request.PreContent;
					post.SubContent = request.SubContent;
					post.PostAvatarUrl = request.PostAvatarUrl;
					post.Content = request.Content;
					post.LastUpdatedBy = user;
					post.LastUpdated = DateTime.UtcNow;

					post.Tags.Clear();
					post.Tags = _tagsService.GetTagsById(request.Tags);
				}

				return await context.SaveChangesAsync();
			}
		}

		public async Task<PostItem> GetPostDetails(int postId)
		{
			var postItem = new PostItem();

			using (var context = this.Context)
			{
				var post = context.Posts.Include("Tags").Include("Ratings").FirstOrDefault(d => d.PostId == postId);

				postItem.PostId = post.PostId;
				postItem.SubContent = post.SubContent;
				postItem.PreContent = post.PreContent;
				postItem.PostAvatarUrl = post.PostAvatarUrl;
				postItem.SubTitle = post.SubTitle;
				postItem.Title = post.Title;
				postItem.SubTitle = post.SubTitle;
				postItem.Content = post.Content;
				postItem.LastUpdatedOn = post.LastUpdated;
				postItem.CreatedBy = post.CreatedBy.UserName;
				postItem.LastUpdatedBy = post.LastUpdatedBy?.UserName;

				postItem.RatingScore = (int)(await _ratingsService.GetPostAvarageRating(post.PostId));

				postItem.Tags = post.Tags.Select(t => new TagItem { TagId = t.TagId, Name = t.Name }).ToList();

			}
			return postItem;
		}
	}
}