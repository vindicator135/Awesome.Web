using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome.Web.Api.Models.Response
{
	public class BaseResponse
	{
		public List<Error> Errors { get; set; }
	}
}