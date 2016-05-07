using Awesome.Web.Api.Models;
using Awesome.Web.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Awesome.Web.Api.Controllers
{
	[EnableCors(origins: "http://localhost:1999", headers: "*", methods: "*")]
	public class LoginController : ApiController
	{
		private IAuthorizationService _authService;

		public LoginController(IAuthorizationService authService)
		{
			this._authService = authService;
		}

		[HttpPost]
		[Route("api/login")]
		public async Task<bool> Login([FromBody] LoginRequest request)
		{
			return await this._authService.Login(request.userName, request.password);
		}
	}
}