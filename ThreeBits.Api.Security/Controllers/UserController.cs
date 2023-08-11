using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreeBits.Business.Filters;
using ThreeBits.Business.Helpers;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security.Security;
using ThreeBits.Interfaces.Security.Users;

namespace ThreeBits.Api.Security.Controllers
{
    [EnableCors("ThreeBitsPolicy")]
    [ApiController]
    [xAppIdHeader(true)]
    [Route("api/v1/User")]
    public class UserController : _BaseController
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserServiceBR _service;
        private readonly ISecurityServiceBR _securityServiceBR;
        HttpContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(ILogger<LoginController> logger, IUserServiceBR service, IHttpContextAccessor httpContextAccessor, ISecurityServiceBR securityServiceBR)
        {
            _logger = logger;
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _securityServiceBR = securityServiceBR;
        }


        /// <summary>
        /// Crear Usuario.
        /// </summary>
        [HttpPost]
        [Route("insUsuario")]
        [Authorize]
        public ActionResult CrearUsuario([FromBody] DatosUsuarioBE item)
        {
            UsuariosBE oUserBE = new UsuariosBE();
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
                if (!string.IsNullOrEmpty(item.Usuario.PASSWORD))
                {
                    string spass = string.Empty;
                    spass = item.Usuario.PASSWORD.ToString();
                    EncryptionBE oEncript = new EncryptionBE();
                    oEncript = _securityServiceBR.encryptDesEncrypt(1, item.Usuario.PASSWORD, oApp.IDAPLICACION);
                    item.Usuario.PASSWORD = oEncript.VALOROUT;
                }
                oUserBE = _service.addUsuario(item.Reglas, item.Usuario, item.Domicilios, item.Contactos, item.RolesXUsuario, item.App);
                oRes.flag = true;
                oRes.data = oUserBE;
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;                
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }
      
        /// <summary>
        /// Obtener Usuario
        /// </summary>
        /// <param name="item">ReglasBE</param>
        /// <returns>DatosUsuarioBE</returns>
        [HttpPost]
        [Route("getUsuarioFull")]
        [Authorize]
        public ActionResult GetrUsuario(ReglasBE item)
        {
           ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {
              
                oRes.flag = true;
                oRes.data = _service.getUsuarioFull(item, oApp.IDAPLICACION); ;
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }
       
        /// <summary>
        /// Activate / Deactivate Usuario
        /// </summary>
        /// <param name="item">ReglasBE</param>
        /// <returns></returns>
        [HttpPost]
        [Route("actDeactivateUsuario")]
        [Authorize]
        public ActionResult actDeactivateUsuario(ReglasBE item)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.actDeactivateUsuario(item, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// Update Usuario
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updUsuario")]
        [Authorize]
        public ActionResult updateUsuario([FromBody] DatosUsuarioBE item)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.updateUsuario(item.Reglas,item.Usuario,item.Domicilios,item.Contactos,item.RolesXUsuario, oApp.IDUSUARIO);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

       /// <summary>
       /// Agregar Roles x Usuario
       /// </summary>
       /// <param name="Reglas"></param>
       /// <param name="RolesXUsuario"></param>
       /// <returns></returns>
        [HttpPost]
        [Route("addRolesXUsuario")]
        [Authorize]
        public ActionResult addRolesXUsurario([FromBody] ReglasBE Reglas, [FromBody] List<RolesXUsuarioBE> RolesXUsuario)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.addRolesXUsuario(Reglas, RolesXUsuario, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

       /// <summary>
       /// Usuario X Aplicacion
       /// </summary>
       /// <param name="Reglas"></param>
       /// <param name="lstUSuarioXApp"></param>
       /// <returns></returns>
        [HttpPost]
        [Route("addUsuarioXAplicacion")]
        [Authorize]
        public ActionResult addUsuarioXAplicacion(ReglasBE Reglas, List<UsuarioXAppBE> lstUSuarioXApp)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.addUsuarioXAplicacion(Reglas, lstUSuarioXApp, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <param name="lstUSuarioXApp"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUsuarios")]
        [Authorize]
        public ActionResult GetUsuarios(ReglasBE Reglas, List<UsuarioXAppBE> lstUSuarioXApp)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.addUsuarioXAplicacion(Reglas, lstUSuarioXApp, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUsuario")]
        [Authorize]
        public ActionResult GetUsuario(UsuariosBE item)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.GetUsuario(item, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRolesVsUser")]
        [Authorize]
        public ActionResult GetRolesVsUser(ReglasBE Reglas)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.GetRolesVsUser(Reglas, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getRolesXApp")]
        [Authorize]
        public ActionResult getRolesXApp(ReglasBE Reglas)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.getRolesXApp(Reglas, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getAppXUsuario")]
        [Authorize]
        public ActionResult getAppXUsuario(ReglasBE Reglas)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.getAppXUsuario(Reglas, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getEstacionesXApp")]
        [Authorize]
        public ActionResult getEstacionesXApp(ReglasBE Reglas)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.getEstacionesXApp(Reglas, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getRelTipoUsuario")]
        [Authorize]
        public ActionResult getRelTipoUsuario(ReglasBE Reglas)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.getRelTipoUsuario(Reglas, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getCatSelection")]
        [Authorize]
        public ActionResult getCatSelection(int IdCatGeneral, int IdSubCatalogo)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.getCatSelection(IdCatGeneral,IdSubCatalogo,oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateRol")]
        [Authorize]
        public ActionResult updateRol(ReglasBE Reglas, RolesXUsuarioBE RolXUsuario)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.updateRol(Reglas, RolXUsuario, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getUsuariosXRol")]
        [Authorize]
        public ActionResult getUsuariosXRol(long IdRol)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.getUsuariosXRol(IdRol, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addUserAut")]
        [Authorize]
        public ActionResult addUserAut(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario)
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.addUserAut(Reglas,Usuario,Domicilios,Contactos, RolesXUsuario, oApp.IDAPLICACION);
                oRes.errorMessage = "";
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return Ok(oRes);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reglas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getUsrIdApp")]
        [Authorize]
        public ActionResult getUsrIdApp()
        {
            ProcessResult oRes = new ProcessResult();
            AplicacionBE oApp = new AplicacionBE();
            var xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
            oApp = _securityServiceBR.getAppInfo(xAppId);
            try
            {

                oRes.flag = true;
                oRes.data = _service.getUsrIdApp(oApp.IDAPLICACION);
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
