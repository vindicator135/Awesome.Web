namespace Awesome.Web.Api.Models.Request
{
	public class CommentSearchRequest : BaseSearchRequest
	{
		public int CommentId { get; set; }

		public int PostId { get; set; }
	}
}