using System.Collections.Generic;

namespace Awesome.Web.Api.Models.Request
{
	public class PostUpdateRequest
	{
		public int PostId { get; set; }

		public string Content { get; set; }

		public List<int> Tags { get; set; }

		public string LastUpdatedBy { get; set; }

		public string CreatedBy { get; set; }
		public string SubTitle { get; set; }
		public string Title { get; set; }
		public string SubContent { get; set; }
		public string TitleText { get; set; }
		public string PreContent { get; set; }
		public string PostAvatarUrl { get; set; }
	}
}