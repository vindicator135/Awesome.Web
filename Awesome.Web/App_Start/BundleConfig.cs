using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Awesome.Web
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
 			bundles.Add(new ScriptBundle("~/bundles/awesome-bundle/angular-stuff").Include(
				"~/Scripts/jquery-{version}.js",
				"~/Scripts/jquery.signalR-2.2.0.js",
				"~/Scripts/angular.js",
				"~/Scripts/angular-ui-router.js",
				"~/Scripts/signalr-hub.js"
				));

			bundles.Add(new ScriptBundle("~/bundles/awesome-bundle/awesome-angular-stuff").Include(
				"~/app/lib/app.ng.js",
				"~/app/routes.ng.js",
				"~/app/_references.js",
				"~/app/controllers/mainApp.ng.js",
				"~/app/discussions/controllers/discussionDetails.ng.js",
				"~/app/discussions/controllers/discussionsList.ng.js",
				"~/app/discussions/services/discussionService.ng.js"
				));

			bundles.Add(new StyleBundle("~/bundles/awesome-bundle/bootstrap-css").Include(
				"~/Content/bootstrap-theme.css",
				"~/Content/bootstrap.css",
				"~/Content/Site.css"
				));

			bundles.Add(new ScriptBundle("~/bundles/awesome-bundle/bootstrap-js").Include(
				"~/Scripts/bootstrap.js"
				));
		}
	}
}
