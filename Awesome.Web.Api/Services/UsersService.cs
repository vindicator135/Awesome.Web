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
	}
}