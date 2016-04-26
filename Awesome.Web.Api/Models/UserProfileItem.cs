using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesome.Web.Api.Models
{
	public class UserProfileItem
	{
		public string AvatarUrl { get; set; }

		public Guid UserId { get; set; }
	}
}
