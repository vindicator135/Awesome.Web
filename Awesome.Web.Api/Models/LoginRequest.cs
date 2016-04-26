using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome.Web.Api.Models
{
	public class LoginRequest
	{
		public string userName { get; set; }

		public string password { get; set; }
	}
}