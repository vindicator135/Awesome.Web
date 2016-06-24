using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Awesome.Web.Api.Common
{
	public partial class SendInBlue
	{
		public dynamic AddUserToAwesomeWebList(string name, string email, params int[] listIds)
		{
			var attributesDictionary = new Dictionary<string, string>();
			attributesDictionary.Add("NAME", name);

			var newUser = new
			{
				email = email,
				attributes = attributesDictionary,
				listid = listIds,
			};

			return this.create_update_user(newUser); ;
		}
	}
}