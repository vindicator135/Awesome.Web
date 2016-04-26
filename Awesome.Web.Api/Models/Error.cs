using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesome.Web.Api.Models
{
	public class Error
	{
		public ErrorCode ErrorCode { get; set; }

		public string ErrorMessage { get; set; }
	}
}
