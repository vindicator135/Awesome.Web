using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Awesome.Web.Api.Filters
{
	public class AwesomeWebExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext context)
		{
			var logger = LogManager.GetLogger("AwesomeWeb");

			logger.Error(context.Exception, $"Exception encountered processing URL {context.ActionContext.Request.RequestUri.ToString()}");
		}
	}
}