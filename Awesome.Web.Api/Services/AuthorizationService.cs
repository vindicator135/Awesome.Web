using Awesome.Entities;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public class AuthorizationService : BaseService, IAuthorizationService
	{
		public AuthorizationService(IDbContextFactory<AwesomeEntities> factory) : base(factory)
		{
			this.factory = factory;
		}

		public Task<bool> Login(string userName, string password)
		{
			using (var context = this.factory.Create())
			{
				var result = context.Users.Where(u => u.UserName == userName && u.Password == password).Select(u => u).FirstOrDefault();

				return Task.FromResult<bool>(result != null);
			}
		}
	}
}