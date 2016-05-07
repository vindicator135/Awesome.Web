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

		public List<Guid> Tags { get; set; }

		public Guid CreatedBy { get; set; }

		public Guid LastUpdatedBy { get; set; }
	}
}