using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using ThreeBits.Business.Helpers;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.School;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.School;
using ThreeBits.Interfaces.Security.Security;

namespace ThreeBits.Api.School.Controllers
{
	public class SchoolController : _BaseController
	{
		private readonly ILogger<SchoolController> _logger;

		private readonly ISchoolServiceBR _service;

		private readonly ISecurityServiceBR _securityServiceBR;

		private readonly IHttpContextAccessor _httpContextAccessor;

		public SchoolController(ILogger<SchoolController> logger, ISchoolServiceBR service, IHttpContextAccessor httpContextAccessor, ISecurityServiceBR securityServiceBR)
		{
			_logger = logger;
			_service = service;
			_httpContextAccessor = httpContextAccessor;
			_securityServiceBR = securityServiceBR;
		}

		[HttpPost]
		[Route("getAlumnos")]
		public ActionResult getAlumnos(reqAlumnosBusqueda oAlumnoEnt)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.ListaAlumnos(oAlumnoEnt);
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
		[Route("getAlumnosByGrado")]
		[Authorize]
		public ActionResult getAlumnosByGradoGrupo(string idGrupo, string idGrado, string idCiclo)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.ListaAlumnosGrupo(idGrupo, idGrado, idCiclo);
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
		[Route("insAlumno")]
		[Authorize]
		public ActionResult insAlumno(AlumnosBE item)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.fnRegistraAlumnoBus(item);
				oRes.errorMessage = "Se registro correctamente el Alumno: " + item.sNombres + " " + item.sAPaterno + " " + item.sAMaterno;
			}
			catch (Exception ex)
			{
				oRes.flag = false;
				oRes.errorMessage = ex.Message.ToString();
			}
			return Ok(oRes);
		}

		[HttpGet]
		[Route("getGrado")]
		[Authorize]
		public ActionResult getGrado(string sNivel)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.ObtieneGrado(sNivel);
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
		[Route("insGradoGrupo")]
		[Authorize]
		public ActionResult insGradoGrupo(string idGrado, string idCiclo)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.ListaAlumnosGrupoAdd(idGrado, idCiclo);
				oRes.errorMessage = "Registro Exitoso";
			}
			catch (Exception ex)
			{
				oRes.flag = false;
				oRes.errorMessage = ex.Message.ToString();
			}
			return Ok(oRes);
		}

		[HttpGet]
		[Route("getAlumnosFull")]
		[Authorize]
		public ActionResult getAlumnosFull(string idColegio)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.ListaAlumnosSearch(idColegio);
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
		[Route("getAlumnoById")]
		[Authorize]
		public ActionResult getAlumnoById(string idAlumno)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.ObtieneAlumno(idAlumno);
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
		[Route("getInfoAlumnoById")]
		[Authorize]
		public ActionResult getInfoAlumnoById(string idAlumno)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.ObtieneInfAlumnoBus(idAlumno);
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
		[Route("getAlumnoById2")]
		[Authorize]
		public ActionResult getAlumnoById2(string idAlumno)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.ObtieneAlumno2(idAlumno);
				oRes.errorMessage = "";
			}
			catch (Exception ex)
			{
				oRes.flag = false;
				oRes.errorMessage = ex.Message.ToString();
			}
			return Ok(oRes);
		}

		//[HttpGet]
		//[Route("getAlumnoRpt")]
		//[Authorize]
		//public ActionResult ObtieneAlumnoRpt(string sMatricula)
		//{
		//	ProcessResult oRes = new ProcessResult();
		//	AplicacionBE oApp = new AplicacionBE();
		//	StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
		//	oApp = _securityServiceBR.getAppInfo(xAppId);
		//	try
		//	{
		//		oRes.flag = true;
		//		oRes.data = _service.ObtieneAlumnoRpt(sMatricula);
		//	}
		//	catch (Exception ex)
		//	{
		//		oRes.flag = false;
		//		oRes.errorMessage = ex.Message.ToString();
		//	}
		//	return Ok(oRes);
		//}

		[HttpPost]
		[Route("asignaAlumnoGrupo")]
		[Authorize]
		public ActionResult AsignaAlumnoGrupo(string idAlumno, string grupo, string ciclo, string user)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.AsignaAlumnoGrupo(idAlumno, grupo, ciclo, user);
				oRes.errorMessage = "Registro Exitoso";
			}
			catch (Exception ex)
			{
				oRes.flag = false;
				oRes.errorMessage = ex.Message.ToString();
			}
			return Ok(oRes);
		}

		[HttpGet]
		[Route("getListaPagosAlumno")]
		[Authorize]
		public ActionResult getPagosAlumno(string idAlumno)
		{
			ProcessResult oRes = new ProcessResult();
			AplicacionBE oApp = new AplicacionBE();
			StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
			oApp = _securityServiceBR.getAppInfo(xAppId);
			try
			{
				oRes.flag = true;
				oRes.data = _service.ListaPagosAlumno(idAlumno);
			}
			catch (Exception ex)
			{
				oRes.flag = false;
				oRes.errorMessage = ex.Message.ToString();
			}
			return Ok(oRes);
		}

		//[HttpGet]
		//[Route("getReciboAlumno")]
		//[Authorize]
		//public ActionResult getReciboAlumno(string idAlumno)
		//{
		//	ProcessResult oRes = new ProcessResult();
		//	AplicacionBE oApp = new AplicacionBE();
		//	StringValues xAppId = _httpContextAccessor.HttpContext.Request.Headers["XAPPID"];
		//	oApp = _securityServiceBR.getAppInfo(xAppId);
		//	try
		//	{
		//		oRes.flag = true;
		//		oRes.data = _service.ObtieneRecibo(idAlumno);
		//	}
		//	catch (Exception ex)
		//	{
		//		oRes.flag = false;
		//		oRes.errorMessage = ex.Message.ToString();
		//	}
		//	return Ok(oRes);
		//}
	}
}
