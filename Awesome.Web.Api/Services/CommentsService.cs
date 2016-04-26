using Awesome.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public class CommentsService : ICommentsService
	{
		private AwesomeEntities _context;

		private IUsersService _usersService;

		public CommentsService(AwesomeEntities context, IUsersService usersService)
		{
			_context = context;

			_usersService = usersService;
		}

		public async Task<List<CommentItem>> GetComments(Guid discussionId, int numberOfMaxRecords)
		{
			var result = new List<CommentItem>();

			var discussionComments = _context.Get<Discussion>().Include("Comments").FirstOrDefault(d => d.DiscussionId == discussionId);

			if (discussionComments != null)
			{
				var comments = discussionComments.Comments.Select(c=>c).OrderByDescending(x => x.LastUpdated).Take(numberOfMaxRecords).ToList();

				if (comments.Any())
				{
					foreach (var comment in comments)
					{
						var commentItem = new CommentItem
												{
													UserAvatarUrl = _usersService.GetUserAvatarUrl(comment.CreatedBy),
													Content = comment.Content,
													CreatedByName = _usersService.GetUserName(comment.CreatedBy),
													LastUpdated = comment.LastUpdated,
												};

						result.Add(commentItem);
					}
				}
			}

			return result;
		}
	}
}
