using System;

namespace Awesome.Web.Api.Models
{
	public class CommentItem
	{
		public string UserAvatarUrl { get; set; }

		public Guid? CreatedBy { get; set; }

		public string Content { get; set; }

		public DateTime? LastUpdated { get; set; }

		public string CreatedByName { get; set; }
	}
}