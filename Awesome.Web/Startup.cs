﻿using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(Awesome.Web.Startup))]
namespace Awesome.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
 			// Any connection or hub wire up and configuration should go here
			// Branch the pipeline here for requests that start with "/signalr"
			app.Map("/signalr", map =>
			{
				// Setup the CORS middleware to run before SignalR.
				// By default this will allow all origins. You can 
				// configure the set of origins and/or http verbs by
				// providing a cors options with a different policy.
				map.UseCors(CorsOptions.AllowAll);
				var hubConfiguration = new HubConfiguration
				{
					EnableDetailedErrors = true,
					EnableJSONP = true,
					EnableJavaScriptProxies = true
				};
				// Run the SignalR pipeline. We're not using MapSignalR
				// since this branch already runs under the "/signalr"
				// path.
				map.RunSignalR(hubConfiguration);
			});
		}
	}
}