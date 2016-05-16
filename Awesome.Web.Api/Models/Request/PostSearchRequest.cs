using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesome.Web.Api.Models.Request
{
	public class PostSearchRequest : BaseSearchRequest
	{

		public int PostId { get; set; }
		public string Tags { get; set; }
	}


}
