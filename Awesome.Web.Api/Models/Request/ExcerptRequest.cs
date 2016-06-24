using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome.Web.Api.Models.Request
{
	public class ExcerptRequest
	{
		public int BookId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string RequestedBy { get; set; }
	}
}