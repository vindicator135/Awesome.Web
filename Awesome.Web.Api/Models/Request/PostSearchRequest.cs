using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesome.Web.Api.Models.Request
{
	public class PostSearchRequest
	{
		public int PostId { get; set; }

		public int Grouping { get; set; }

		public string Search { get; set; }

		public int MaxResults { get; set; }
		public int Top { get; internal set; }
	}


}
