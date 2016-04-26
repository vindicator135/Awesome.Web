using System;
using System.Collections.Generic;

namespace Awesome.Web.Api.Models
{
	public class DiscussionItem
	{
		public DiscussionItem()
		{
			this.Comments = new List<CommentItem>();

			this.Tags = new List<TagItem>();
		}

		public Guid DiscussionId { get; set; }

		public string Content { get; set; }

		public List<CommentItem> Comments { get; set; }

		public List<TagItem> Tags { get; set; }

		public int RatingScore { get; set; }

		public DateTime? LastUpdatedOn { get; set; }

		public string LastUpdatedBy { get; set; }
	}
}