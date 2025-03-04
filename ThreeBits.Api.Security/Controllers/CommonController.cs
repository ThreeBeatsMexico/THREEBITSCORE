using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using ThreeBits.Business.Filters;
using ThreeBits.Business.Helpers;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.Common;
using ThreeBits.Interfaces.Security.Security;


namespace ThreeBits.Api.Security.Controllers
{
	[EnableCors("ThreeBitsPolicy")]
	[ApiController]
	[xAppIdHeader(true)]
	[Route("api/v1/Security/Common")]
	public class CommonController : _BaseController
	{
		private readonly ILogger<CommonController> _logger;

		private readonly ICommonServiceBR _service;

		private readonly ISecurityServiceBR _serviceBR;

		private HttpContext context;

		private readonly IHttpContextAccessor _httpContextAccessor;

		public CommonController(ILogger<CommonController> logger, ICommonServiceBR service, IHttpContextAccessor httpContextAccessor, ISecurityServiceBR serviceBR)
		{
			_logger = logger;
			_service = service;
			_httpContextAccessor = httpContextAccessor;
			_serviceBR = serviceBR;
		}

		[HttpPost]
		[Route("getCatGenerales")]
		[Authorize]
		public ActionResult getCatGenerales(CatGeneralesBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _serviceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.GetCatGenerales(item);
				oRes.errorMessage = "";
			}
			catch (Exception ex)
			{
				oRes.flag = false;
				oRes.errorMessage = ex.Message.ToString();
			}
			return Ok(oRes);
		}
	}

}
