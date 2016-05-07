using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Awesome.Web.Api.Startup))]

namespace Awesome.Web.Api
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}