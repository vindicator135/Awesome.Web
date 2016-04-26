using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Awesome.Entities;
using Awesome.Web.Api.Services;
using System.Data.Entity;

namespace Awesome.Web.Api
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);

			SetupContainer();
		}

		private void SetupContainer()
		{
			var builder = new ContainerBuilder();

			// Get your HttpConfiguration.
			var config = GlobalConfiguration.Configuration;

			// Register your Web API controllers.
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			// OPTIONAL: Register the Autofac filter provider.
			builder.RegisterWebApiFilterProvider(config);

			// Structure the dependencies
			builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();
			builder.RegisterType<CommentsService>().As<ICommentsService>();
			builder.RegisterType<DiscussionsService>().As<IDiscussionsService>();
			builder.RegisterType<RatingsService>().As<IRatingsService>();
			builder.RegisterType<TagsService>().As<ITagsService>();
			builder.RegisterType<UsersService>().As<IUsersService>();

			builder.RegisterType<AwesomeEntities>().As<AwesomeEntities>()
				.WithParameter("nameOrConnectionString", "DefaultConnection")
				.InstancePerLifetimeScope();

			// Set the dependency resolver to be Autofac.
			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}