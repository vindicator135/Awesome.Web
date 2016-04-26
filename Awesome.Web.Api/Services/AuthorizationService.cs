using Awesome.Entities;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public class AuthorizationService : IAuthorizationService
	{
		private AwesomeEntities _context;

		public AuthorizationService(AwesomeEntities context)
		{
			this._context = context;
		}

		public Task<bool> Login(string userName, string password)
		{
			using (var context = this._context)
			{
				var result = context.Users.Select(u => u.UserName == userName && u.Password == password).FirstOrDefault();

				return Task.FromResult<bool>(result);
			}
		}
	}
}