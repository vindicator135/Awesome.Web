using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesome.Web.Api.Models.Request
{
	public class TagSearchRequest : BaseSearchRequest
	{
		public int TagId { get; set; }
	}


}
