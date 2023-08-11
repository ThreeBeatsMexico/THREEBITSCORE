using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ThreeBits.Business.Filters;
using ThreeBits.Business.Helpers;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.Security.Common;
using ThreeBits.Interfaces.Security.Security;


namespace ThreeBits.Api.Security.Controllers
{
    [EnableCors("ThreeBitsPolicy")]
    // [EnableCors]
    [ApiController]
    [xAppIdHeader(true)]
    [Route("api/v1/Security")]
    public class CommonController : _BaseController
    {
        private readonly ILogger<CommonController> _logger;
        private readonly ICommonServiceBR _service;
        private readonly ISecurityServiceBR _serviceBR;
        HttpContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommonController(ILogger<CommonController> logger, ICommonServiceBR service, IHttpContextAccessor httpContextAccessor, ISecurityServiceBR serviceBR )
        {
            _logger = logger;
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _serviceBR = serviceBR;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Rol"></param>
        /// <param name="Pagina"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCatGenerales")]
        [Authorize]
        public ActionResult getCatGenerales(CatGeneralesBE item)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _serviceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _service.GetCatGenerales(item); ;
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
