using Awesome.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Awesome.Web.Api.Services
{
	public class CommentsService : BaseService, ICommentsService
	{
		private IUsersService _usersService;

		public CommentsService(IDbContextFactory<AwesomeEntities> factory, IUsersService usersService) : base(factory)
		{
			_usersService = usersService;
		}

		public async Task<List<CommentItem>> GetComments(int postId, int numberOfMaxRecords)
		{
			var result = new List<CommentItem>();

			var postComments = this.Context.Posts.Include(x => x.Comments).Include(x => x.Comments.Select(y => y.CreatedBy)).FirstOrDefault(d => d.PostId == postId);

			if (postComments != null)
			{
				var comments = postComments.Comments.Select(c => c).OrderByDescending(x => x.LastUpdated).Take(numberOfMaxRecords).ToList();

				if (comments.Any())
				{
					foreach (var comment in comments)
					{
						var commentItem = new CommentItem
						{
							UserAvatarUrl = comment.CreatedBy.AvatarUrl,
							Content = comment.Content,
							CreatedByName = comment.CreatedBy.UserName,
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