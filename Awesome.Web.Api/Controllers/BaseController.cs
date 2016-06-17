using Awesome.Web.Api.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Awesome.Web.Api.Controllers
{
	[AwesomeWebExceptionFilter]
	public abstract class BaseController : ApiController
	{
		protected Logger _logger = LogManager.GetLogger("AwesomeWeb");

	}
}