using System;
using System.Collections.Generic;
using Awesome.Entities;

namespace Awesome.Web.Api.Models
{
	public class CommentItem
	{
		public string AvatarUrl { get; set; }
		public string Content { get; set; }
		public DateTime? LastUpdated { get; set; }
		public string CreatedByName { get; set; }
		public int CommentId { get; set; }
		public List<CommentItem> Children { get; set; }
		public ICollection<Comment> ChildrenRaw { get; set; }
		public string UserWebSite { get; set; }
		public string UserEmail { get; set; }
		public string DisplayCreated { get { return Created.ToString("dd MMM yyyy hh:mm tt"); } }
		public DateTime Created { get; set; }
		public int PostId { get; set; }
		public int? ParentId { get; set; }
		public string Title { get; set; }
	}
}