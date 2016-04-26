using Awesome.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface IUsersService
	{
		string GetUserName(Guid? userId);

		string GetUserAvatarUrl(Guid userId);

		Task<UserItem> GetUser(Guid? userId);
	}
}
