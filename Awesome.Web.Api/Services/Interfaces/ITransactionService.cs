using Awesome.Web.Api.Models;
using Awesome.Web.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awesome.Web.Api.Services
{
	public interface ITransactionService
	{
		Task CompleteBookSale(Dictionary<string, string> ipn);
	}
}
