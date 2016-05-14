using System;
using System.Collections.Generic;

namespace Awesome.Web.Api.Models
{
	public class PostItem
	{
		public PostItem()
		{
			this.Comments = new List<CommentItem>();

			this.Tags = new List<TagItem>();
		}

		public int PostId { get; set; }

		public string Content { get; set; }

		public List<CommentItem> Comments { get; set; }

		public List<TagItem> Tags { get; set; }

		public int RatingScore { get; set; }

		public DateTime? LastUpdatedOn { get; set; }

		public string LastUpdatedBy { get; set; }

		public string CreatedBy { get; set; }
		public string SubContent { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string PreContent { get; internal set; }
		public string PostAvatarUrl { get; set; }
		public string TitleText { get; set; }
	}
}