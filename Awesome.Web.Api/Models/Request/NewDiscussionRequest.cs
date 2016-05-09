using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome.Web.Api.Models.Request
{
	public class PostUpdateRequest
	{
		public Guid PostId { get; set; }

		public string Content { get; set; }

		public List<int> Tags { get; set; }

		public string LastUpdatedByUserName { get; set; }

		public string CreatedByUserName { get; internal set; }
	}
}