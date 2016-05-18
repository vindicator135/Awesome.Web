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
	public class CommentsService : BaseService, ICommentsService
	{
		public CommentsService(IDbContextFactory<AwesomeEntities> factory) : base(factory)
		{
		}

		public async Task<int> AddComment(CommentUpdateRequest request)
		{
			using (var context = this.Context)
			{
				// Once we get people to sign up and have their own accounts, this should be based on the request.UserName
				// for now, we just use the 'admin'
				var user = context.Users.FirstOrDefault(u => u.UserName == request.CreatedBy);

				var comment = new Comment
				{
					AvatarUrl = request.AvatarUrl,
					Content = request.Content,
					PostId = request.PostId,
					UserName = request.UserName,
					UserEmail = request.UserEmail,
					UserWebSite = request.UserWebSite,
					Created = DateTime.UtcNow,
					CreatedBy = user
				};

				context.Comments.Add(comment);

				return await context.SaveChangesAsync();
			}
		}

		public async Task<int> DeleteComment(int commentId)
		{
			using (var context = this.Context)
			{
				var comment = context.Comments.FirstOrDefault(c => c.CommentId == commentId);

				if (comment != null)
					context.Comments.Remove(comment);

				return await context.SaveChangesAsync();
			}
		}

		public async Task<int> EditComment(CommentUpdateRequest request)
		{
			using (var context = this.Context)
			{
				var comment = context.Comments.FirstOrDefault(c => c.CommentId == request.CommentId);

				if (comment != null)
				{
					var user = context.Users.FirstOrDefault(u => u.UserName == request.LastUpdatedBy);

					comment.Content = request.Content;
					comment.AvatarUrl = request.AvatarUrl;
					comment.UserEmail = request.UserEmail;
					comment.UserName = request.UserName;
					comment.UserWebSite = request.UserWebSite;
					comment.LastUpdatedBy = user;
					comment.LastUpdated = DateTime.UtcNow;
				}

				return await context.SaveChangesAsync();
			}
		}

		public async Task<List<CommentItem>> SearchComments(CommentSearchRequest request)
		{
			var result = new List<CommentItem>();

			var commentQuery = this.Context.Comments.Include("Post").Include("Parent").Include("Children").Select(c => c);

			if (request.PostId > 0)
			{
				commentQuery = commentQuery.Where(c => c.PostId == request.PostId);

				var rawComments = commentQuery.ToList();

				result = rawComments.Select(c => new CommentItem
				{
					Content = c.Content,
					AvatarUrl = c.AvatarUrl,
					CreatedByName = c.UserName,
					UserWebSite = c.UserWebSite,
					UserEmail = c.UserEmail,
					CommentId = c.CommentId,
					ChildrenRaw = c.Children,
					PostId = c.PostId,
					Created = c.Created,
					ParentId = c.Parent?.CommentId
				}).ToList();

				// I decided to first ToList the Query so I can do more post-query processing on the Comment.Children
				//  Two iteraitons isn't so bad since I don't think LINQ will allow this GetNestedCommentItems method within the LINQ Query itself
				result.ForEach(r => GetNestedCommentItems(r.ChildrenRaw, r));

				return result;
			}

			if (request.Top > 0)
			{
				commentQuery = commentQuery.OrderByDescending(c => c.Created).Take(request.Top);
			}

			if (!string.IsNullOrEmpty(request.Search))
			{
				commentQuery = commentQuery.Where(c => c.Content.Contains(request.Search));
			}

			result = commentQuery.Select(c => new CommentItem
			{
				Content = c.Content,
				AvatarUrl = c.AvatarUrl,
				CreatedByName = c.UserName,
				UserWebSite = c.UserWebSite,
				UserEmail = c.UserEmail,
				CommentId = c.CommentId,
				PostId = c.PostId,
				Created = c.Created,
				Title = c.Post.TitleText
			}).ToList();

			return result;
		}

		private void GetNestedCommentItems(ICollection<Comment> children, CommentItem parent)
		{
			foreach (var child in children)
			{
				var childItem = new CommentItem
				{
					Content = child.Content,
					AvatarUrl = child.AvatarUrl,
					CreatedByName = child.UserName,
					CommentId = child.CommentId,
					UserWebSite = child.UserWebSite,
					UserEmail = child.UserEmail,
					PostId = child.PostId,
					Created = child.Created,
					ParentId = parent.CommentId,
					ChildrenRaw = child.Children
				};

				parent.Children.Add(childItem);

				if (childItem.ChildrenRaw.Count > 0)
					GetNestedCommentItems(child.Children, childItem);
			}
		}
	}
}