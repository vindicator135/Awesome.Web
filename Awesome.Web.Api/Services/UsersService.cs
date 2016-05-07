using Awesome.Entities;
using Awesome.Web.Api.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public class UsersService : BaseService, IUsersService
	{
		public UsersService(IDbContextFactory<AwesomeEntities> factory) : base(factory)
		{
		}

		public string GetUserName(Guid? userId)
		{
			var user = GetUser(userId).Result;

			return user != null ? user.UserName : string.Empty;
		}

		public async Task<UserItem> GetUser(Guid? userId)
		{
			UserItem userItem = null;

			if (userId.HasValue)
			{
				var user = await factory.Create().Get<User>().FindAsync(userId.Value);

				userItem = new UserItem()
				{
					UserName = user.UserName,
				};
			}

			return userItem;
		}

		public async Task<UserProfileItem> GetUserProfile(Guid? userId)
		{
			UserProfileItem profileItem = null;

			if (userId.HasValue)
			{
				var user = factory.Create().Get<User>().Include("UserProfile").FirstOrDefault(u => u.UserId == userId.Value);

				if (user != null && user.UserProfile != null)
				{
					profileItem = new UserProfileItem
					{
						UserId = userId.Value,
						AvatarUrl = user.UserProfile.AvatarUrl
					};
				}
			}

			return profileItem;
		}

		public string GetUserAvatarUrl(Guid userId)
		{
			var user = GetUserProfile(userId).Result;

			return user != null ? user.AvatarUrl : string.Empty;
		}
	}
}