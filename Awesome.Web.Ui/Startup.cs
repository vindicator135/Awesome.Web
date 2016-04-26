using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Awesome.Web.Ui.Startup))]

namespace Awesome.Web.Ui
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{

		}
	}
}