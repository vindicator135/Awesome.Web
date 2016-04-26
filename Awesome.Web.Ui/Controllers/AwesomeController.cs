using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Awesome.Web.Ui.Controllers
{
	public class AwesomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}