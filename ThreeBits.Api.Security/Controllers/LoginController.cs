using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using ThreeBits.Business.Filters;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.Security.Security;

namespace ThreeBits.Api.Security.Controllers
{
	[EnableCors("ThreeBitsPolicy")]
	[ApiController]
	[xAppIdHeader(true)]
	[Route("api/v1/Security")]
	public class LoginController : _BaseController
	{
		private readonly ILogger<LoginController> _logger;

		private readonly ISecurityServiceBR _service;

		private HttpContext context;

		private readonly IHttpContextAccessor _httpContextAccessor;

		public LoginController(ILogger<LoginController> logger, ISecurityServiceBR service, IHttpContextAccessor httpContextAccessor)
		{
			_logger = logger;
			_service = service;
			_httpContextAccessor = httpContextAccessor;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("Login")]
		public ActionResult Login([FromBody] Credential input)
		{
			ProcessResult oRes = new ProcessResult();
			resAuthenticate oResAuth = new resAuthenticate();
			TokenJwt oToken = new TokenJwt();
			try
			{
				StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
				if (string.IsNullOrEmpty(xAppId) || xAppId == "")
				{
					oRes.flag = false;
					oRes.errorMessage = "Missing XAPPID Header";
					return Unauthorized(oRes);
				}
				input.xAppId = xAppId;
				oRes = _service.authenticate(input);
				return Ok(oRes);
			}
			catch (Exception e)
			{
				oRes.flag = false;
				oRes.errorMessage = e.Message;
				return Conflict(oRes);
			}
		}
	}
}
