using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Awesome.Web.Api.Common
{
	public class AwesomeHelper
	{
		public static HttpResponseMessage Content(object obj, HttpStatusCode status = HttpStatusCode.OK)
		{
			var response = new HttpResponseMessage(status);
			
			response.Content = new StringContent(JsonConvert.SerializeObject(obj));

			return response;
		}
	}
}