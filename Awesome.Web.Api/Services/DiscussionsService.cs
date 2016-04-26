using Awesome.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using Awesome.Web.Api.Models.Request;
using AutoMapper;

namespace Awesome.Web.Api.Services
{
	public class DiscussionsService : IDiscussionsService
	{
		private AwesomeEntities _context;

		private ICommentsService _commentsService;

		private IRatingsService _ratingsService;

		private ITagsService _tagsService;

		private IUsersService _usersService;

		public DiscussionsService(AwesomeEntities context, ICommentsService commentsService, IRatingsService ratingsService, ITagsService tagsService, IUsersService usersService)
		{
			this._context = context;

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
		public async Task<List<DiscussionItem>> SearchDiscussions(string search)
		{
			return await GetDiscussions(search, 1, 5);
		}

		public async Task<List<DiscussionItem>> SearchDiscussions(DiscussionSearchRequest request)
		{
			return await GetDiscussions(request.Search, request.Grouping, request.MaxResults);
		}

		private async Task<List<DiscussionItem>> GetDiscussions(string search, int grouping, int maxResults)
		{
			var result = new List<DiscussionItem>();

			var discussionQuery = _context.Get<Discussion>().Select(d => d);

			if (!string.IsNullOrEmpty(search))
			{
				discussionQuery = discussionQuery.Where(d => d.Content.Contains(search));
			}

			switch (grouping)
			{
				case 1:
					discussionQuery = discussionQuery.OrderByDescending(d => d.LastUpdated);
					break;
				case 2:
					discussionQuery = discussionQuery.OrderByDescending(d => d.Ratings.Sum(r => r.Score));
					break;
				default:
					break;
			}

			if (maxResults > 0)
			{
				discussionQuery = discussionQuery.Take(maxResults);
			}

			var discussionList = discussionQuery.ToList();

			foreach (var discussion in discussionList)
			{
				var discussionItem = await GetDiscussionItem(discussion);

				result.Add(discussionItem);
			}

			return result;
		}

		private async Task<DiscussionItem> GetDiscussionItem(Discussion discussion)
		{
			var discussionItem = new DiscussionItem()
			{
				DiscussionId = discussion.DiscussionId,
				Content = discussion.Content,
				LastUpdatedOn = discussion.LastUpdated,
				LastUpdatedBy = _usersService.GetUserName(discussion.LastUpdatedBy)
			};

			discussionItem.RatingScore = (int)(await _ratingsService.GetDiscussionAvarageRating(discussion.DiscussionId));

			List<CommentItem> comments = await _commentsService.GetComments(discussion.DiscussionId, 3);

			if (comments.FirstOrDefault() != null)
			{
				// Set the Last on to the most recent comment if any
				discussionItem.LastUpdatedOn = comments.First().LastUpdated;

				comments.ForEach(c =>
				{
					discussionItem.Comments.Add(c);
				});
			}

			List<TagItem> tags = await _tagsService.GetDiscussionTags(discussion.DiscussionId);

			if (tags.FirstOrDefault() != null)
			{
				tags.ForEach(t =>
				{
					discussionItem.Tags.Add(t);
				});
			}
			return discussionItem;
		}

		public async Task<object> AddDiscussion(DiscussionUpdateRequest request)
		{
			var discussion = new Discussion
			{
				Content = request.Content,
				CreatedBy = request.CreatedBy,
				Created = DateTime.Now,
				Tags = _tagsService.GetTagsById(request.Tags),
			};

			_context.Discussions.Add(discussion);

			return await _context.SaveChangesAsync();

		}

		public async Task<object> RemoveDiscussion(Guid discussionId)
		{
			var discussion = _context.Discussions.Find(discussionId);

			if (discussion != null)
				_context.Discussions.Remove(discussion);

			return await _context.SaveChangesAsync();
		}


		public async Task<object> EditDiscussion(DiscussionUpdateRequest request)
		{
			var discussion = _context.Discussions.Include("Tags").FirstOrDefault(d => d.DiscussionId == request.DiscussionId);

			if (discussion != null)
			{
				discussion.Content = request.Content;
				discussion.LastUpdatedBy = request.LastUpdatedBy;
				discussion.LastUpdated = DateTime.UtcNow;
				discussion.Tags = _tagsService.GetTagsById(request.Tags);
			}

			return await _context.SaveChangesAsync();
		}
	}
}
