using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreeBits.Business.Filters;
using ThreeBits.Business.Helpers;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.Security.Security;
using ThreeBits.Interfaces.Security.Users;

namespace ThreeBits.Api.Security.Controllers
{
    [EnableCors("ThreeBitsPolicy")]
    [ApiController]
    [xAppIdHeader(true)]
    [Route("api/v1/Security")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserServiceBR _service;
        private readonly ISecurityServiceBR _securityServiceBR;
        HttpContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecurityController(ILogger<LoginController> logger, IUserServiceBR service, IHttpContextAccessor httpContextAccessor, ISecurityServiceBR securityServiceBR)
        {
            _logger = logger;
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _securityServiceBR = securityServiceBR;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Rol"></param>
        /// <param name="Pagina"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getObjetosXAppRolPage")]
        [Authorize]
        public ActionResult getObjetosXAppRolPage(long Rol, string Pagina)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.getObjetosXAppRolPage(Rol, Pagina, oApp.IDAPLICACION); ;
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }


        [HttpGet]
        [Route("getElementsObjectsXIdObj")]
        [Authorize]
        public ActionResult getElementsObjectsXIdObj(long IdPermisosXObj)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.getElementsObjectsXIdObj(IdPermisosXObj, oApp.IDAPLICACION); ;
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpGet]
        [Route("getMenuXAppRol")]
        [Authorize]
        public ActionResult getMenuXAppRol(long Rol)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.getMenuXAppRol(Rol, oApp.IDAPLICACION); ;
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpGet]
        [Route("getSubMenuXIdMenu")]
        [Authorize]
        public ActionResult getSubMenuXIdMenu(long IdPermisoMenu)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.getSubMenuXIdMenu(IdPermisoMenu,oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpGet]
        [Route("getMenuXAppRolAdmin")]
        [Authorize]
        public ActionResult getMenuXAppRolAdmin(long Rol)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.getMenuXAppRolAdmin(Rol, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpGet]
        [Route("getSubMenuXIdMenuAdmin")]
        [Authorize]
        public ActionResult getSubMenuXIdMenuAdmin(long IdPermisoMenu)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.getSubMenuXIdMenuAdmin(IdPermisoMenu, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("encryptDesEncrypt")]
        [Authorize]
        public ActionResult encryptDesEncrypt(int Tipo, string Valor)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.encryptDesEncrypt(Tipo,Valor, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpGet]
        [Route("getAplicaciones")]
        [Authorize]
        public ActionResult getAplicaciones(string idAplicacion, string txtbusqueda)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.getAplicaciones(idAplicacion, txtbusqueda, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("addAplicacion")]
        [Authorize]
        public ActionResult addAplicacion(AplicacionBE Aplicacion)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.addAplicacion(Aplicacion, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPut]
        [Route("updAplicacion")]
        [Authorize]
        public ActionResult updAplicacion(AplicacionBE Aplicacion)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.updAplicacion(Aplicacion, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPut]
        [Route("updMenuxAppRol")]
        [Authorize]
        public ActionResult updMenuxAppRol(Int64 idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.updMenuxAppRol(idMenu,Menu,Img,TpoObj,Url,Tool,Orden,Activo, oApp.IDAPLICACION.ToString());
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPut]
        [Route("updSubMenuxAppRol")]
        [Authorize]
        public ActionResult updSubMenuxAppRol(Int64 idPermisoMenu, Int64 IdPermisoSubmenu, string SubMenu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.updSubMenuxAppRol(idPermisoMenu, IdPermisoSubmenu, SubMenu, Img, TpoObj, Url, Tool, Orden, Activo, oApp.IDAPLICACION.ToString());
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("addRolxApp")]
        [Authorize]
        public ActionResult addRolxApp(string Rol)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.addRolxApp(Rol, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("addMetodo")]
        [Authorize]
        public ActionResult addMetodo(List<WCFMetodosBE> lstMetodos)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.addMetodo(lstMetodos, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("addServicio")]
        [Authorize]
        public ActionResult addServicio(string Servicio, bool Recurrente)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.addServicio(Servicio, oApp.IDAPLICACION, Recurrente);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("addMenuxAppRol")]
        [Authorize]
        public ActionResult addMenuxAppRol(Int64 Rol, string Menu, string Img, string Obj, string Url, string Tool, Int64 Orden)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.addMenuxAppRol(Rol, oApp.IDAPLICACION, Menu,Img,Obj,Url,Tool,Orden);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("addSubMenuxAppRol")]
        [Authorize]
        public ActionResult addSubMenuxAppRol(Int64 IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, Int64 Orden)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.addSubMenuxAppRol(IdSubMenu, SubMenu, Img, Obj, Url, Tool, Orden);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("addPermisosxObjeto")]
        [Authorize]
        public ActionResult addPermisosxObjeto(Int64 IdRol, string Pagina, string Obj, string TipoObj, string Tool)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.addPermisosxObjeto(IdRol, Pagina, Obj, TipoObj, Tool);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("addPermisosxElementoObjeto")]
        [Authorize]
        public ActionResult addPermisosxElementoObjeto(Int64 IdPermiosObj, string Elemento, string Tool)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.addPermisosxElementoObjeto(IdPermiosObj, Elemento, Tool);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpDelete]
        [Route("delMenu")]
        [Authorize]
        public ActionResult delMenu(Int64 IdMenu)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.delMenu(IdMenu,oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpDelete]
        [Route("delSubMenu")]
        [Authorize]
        public ActionResult delSubMenu(Int64 idSubMenu)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.delSubMenu(idSubMenu, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("encryptDecryptChain")]
        [Authorize]
        public ActionResult encryptDecryptChain(int Tipo, string Valor, string Llave)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.encryptDecryptChain(Tipo,Valor,Llave, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        [HttpPost]
        [Route("getAppInfo")]
        [Authorize]
        public ActionResult getAppInfo()
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                oRes.flag = true;
                oRes.data = _securityServiceBR.getAppInfo(oApp.IDAPLICACION.ToString());
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
