﻿using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Awesome.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
			config.EnableCors();

			// Web API configuration and services
			// Configure Web API to use only bearer token authentication.
			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			// Web API routes
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			AutoMapperConfig.Configure();
			AutofacConfig.Configure();
        }
    }
}
