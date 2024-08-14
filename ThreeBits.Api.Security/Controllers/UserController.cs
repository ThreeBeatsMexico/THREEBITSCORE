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

		private HttpContext context;

		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserController(ILogger<LoginController> logger, IUserServiceBR service, IHttpContextAccessor httpContextAccessor, ISecurityServiceBR securityServiceBR)
		{
			_logger = logger;
			_service = service;
			_httpContextAccessor = httpContextAccessor;
			_securityServiceBR = securityServiceBR;
		}

		[HttpPost]
		[Route("insUsuario")]
		[Authorize]
		public ActionResult CrearUsuario([FromBody] DatosUsuarioBE item)
		{
			UsuariosBE oUserBE = new UsuariosBE();
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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

		[HttpPost]
		[Route("getUsuarioFull")]
		[Authorize]
		public ActionResult GetrUsuario(ReglasBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.getUsuarioFull(item, oApp.IDAPLICACION);
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
		[Route("actDeactivateUsuario")]
		[Authorize]
		public ActionResult actDeactivateUsuario(ReglasBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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

		[HttpPut]
		[Route("updUsuario")]
		[Authorize]
		public ActionResult updateUsuario([FromBody] DatosUsuarioBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.updateUsuario(item.Reglas, item.Usuario, item.Domicilios, item.Contactos, item.RolesXUsuario, oApp.IDUSUARIO);
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
		[Route("addRolesXUsuario")]
		[Authorize]
		public ActionResult addRolesXUsurario([FromBody] reqAddRolesxUsuario item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.addRolesXUsuario(item.Reglas, item.RolesXUsuario, oApp.IDAPLICACION);
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
		[Route("addUsuarioXAplicacion")]
		[Authorize]
		public ActionResult addUsuarioXAplicacion([FromBody] reqAddUsuarioxAplicacionBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.addUsuarioXAplicacion(item.Reglas, item.lstUSuarioXApp, oApp.IDAPLICACION);
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
		[Route("GetUsuarios")]
		[Authorize]
		public ActionResult GetUsuarios(UsuariosBE Usuario)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.GetUsuarios(Usuario, oApp.IDAPLICACION);
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
		[Route("GetUsuario")]
		[Authorize]
		public ActionResult GetUsuario(UsuariosBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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

		[HttpPost]
		[Route("GetRolesVsUser")]
		[Authorize]
		public ActionResult GetRolesVsUser(ReglasBE Reglas)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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

		[HttpPost]
		[Route("getRolesXApp")]
		[Authorize]
		public ActionResult getRolesXApp(ReglasBE Reglas)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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

		[HttpPost]
		[Route("getAppXUsuario")]
		[Authorize]
		public ActionResult getAppXUsuario(ReglasBE Reglas)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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

		[HttpPost]
		[Route("getEstacionesXApp")]
		[Authorize]
		public ActionResult getEstacionesXApp(ReglasBE Reglas)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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

		[HttpPost]
		[Route("getRelTipoUsuario")]
		[Authorize]
		public ActionResult getRelTipoUsuario(ReglasBE Reglas)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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

		[HttpPost]
		[Route("getCatSelection")]
		[Authorize]
		public ActionResult getCatSelection(reqCatalogoBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.getCatSelection(item.IdCatGeneral, item.IdSubCatalogo, oApp.IDAPLICACION);
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
		[Route("updateRol")]
		[Authorize]
		public ActionResult updateRol(reqUpdRolBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.updateRol(item.reglas, item.rolesXUsuario, oApp.IDAPLICACION);
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
		[Route("getUsuariosXRol")]
		[Authorize]
		public ActionResult getUsuariosXRol(long IdRol)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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

		[HttpPost]
		[Route("addUserAut")]
		[Authorize]
		public ActionResult addUserAut([FromBody] DatosUsuarioBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.addUserAut(item.Reglas, item.Usuario, item.Domicilios, item.Contactos, item.RolesXUsuario, oApp.IDAPLICACION);
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
		[Route("getUsrIdApp")]
		[Authorize]
		public ActionResult getUsrIdApp()
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
		string xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
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
