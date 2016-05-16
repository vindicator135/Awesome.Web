using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome.Web.Api.Models.Request
{
	public abstract class BaseSearchRequest
	{
		public int Grouping { get; set; }

		public string Search { get; set; }

		public int MaxResults { get; set; }

		public int Top { get; internal set; }
	}
}