namespace Awesome.Web.Api.Models.Request
{
	public class TagUpdateRequest
	{
		public int TagId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string LastUpdatedBy { get; set; }
		public string CreatedBy { get; set; }
	}
}