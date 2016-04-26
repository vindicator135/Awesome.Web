using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface IAuthorizationService
	{
		Task<bool> Login(string userName, string password);
	}
}