﻿using Autofac;
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
using System.Data.Entity.Infrastructure;

namespace Awesome.Web.Api
{
	public static class AutofacConfig
	{
		public static void Configure()
		{
			var builder = new ContainerBuilder();

			// Get your HttpConfiguration.
			var config = GlobalConfiguration.Configuration;

			// Register your Web API controllers.
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			// OPTIONAL: Register the Autofac filter provider.
			builder.RegisterWebApiFilterProvider(config);

			// Structure the dependencies
			builder.RegisterType<CommentsService>().As<ICommentsService>();
			builder.RegisterType<PostsService>().As<IPostsService>();
			builder.RegisterType<RatingsService>().As<IRatingsService>();
			builder.RegisterType<TagsService>().As<ITagsService>();
			builder.RegisterType<UsersService>().As<IUsersService>();
			builder.RegisterType<MarketingService>().As<IMarketingService>();
			builder.RegisterType<TransactionService>().As<ITransactionService>();
			builder.RegisterType<AwesomeContextFactory>().As<IDbContextFactory<AwesomeEntities>>();

			//builder.RegisterType<AwesomeEntities>().As<AwesomeEntities>()
			//	.WithParameter("nameOrConnectionString", "DefaultConnection")
			//	.InstancePerLifetimeScope();

			// Set the dependency resolver to be Autofac.
			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}