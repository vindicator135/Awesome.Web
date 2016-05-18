namespace Awesome.Web.Api.Models.Request
{
	public class CommentUpdateRequest
	{
		public int PostId { get; set; }
		public int CommentId { get; set; }
		public string AvatarUrl { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public string CreatedBy { get; set; }
		public string UserEmail { get; set; }
		public string UserName { get; set; }
		public string UserWebSite { get; set; }
		public string LastUpdatedBy { get; set; }
	}
}