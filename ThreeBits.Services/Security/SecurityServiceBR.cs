using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Business.Security.Security;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security.Security;
using ThreeBits.Interfaces.Security.Users;
using ThreeBits.Shared;

namespace ThreeBits.Services.Security
{
	public class SecurityServiceBR : _BaseService, ISecurityServiceBR
	{
		private readonly ILogger _logger;

		private readonly ISecurityServiceDA _securityServiceDA;

		private readonly IUserServiceBR _userServiceBR;

		private readonly IConfiguration _configuration;

		public string _sIdApp;

		private AplicacionBE oAppBE = new AplicacionBE();

		public SecurityServiceBR(ILogger<SecurityServiceBR> logger, ISecurityServiceDA securityServiceDA, IUserServiceBR userServiceBR, IConfiguration configuration)
		{
			_logger = logger;
			_securityServiceDA = securityServiceDA;
			_userServiceBR = userServiceBR;
			_configuration = configuration;
			_sIdApp = _configuration["TBSettings:IdApp"];
		}

		public ProcessResult authenticate(Credential oCredential)
		{
			Credential CredentialRes = new Credential();
			resAuthenticate oResAuth = new resAuthenticate();
			ProcessResult oRes = new ProcessResult();
			ReglasBE reglas = new ReglasBE();
			DatosUsuarioBE resUsuario = new DatosUsuarioBE();
			int iTpoBusqueda = (oCredential.tipoBusqueda.HasValue ? Convert.ToInt32(oCredential.tipoBusqueda) : 3);
			oAppBE = getAppInfo(oCredential.xAppId.ToString());
			reglas.TIPOBUSQUEDA = iTpoBusqueda;
			reglas.USUARIO = oCredential.userName;
			reglas.IDAPP = oAppBE.IDAPLICACION;
			resUsuario = _userServiceBR.getUsuarioFull(reglas, long.Parse(_sIdApp));
			oRes.flag = false;
			if (resUsuario.Usuario.IDUSUARIO.ToString() == "0")
			{
				oRes.errorMessage = "El Nombre de usuario no existe o no tiene permisos!";
			}
			else if (!resUsuario.Usuario.ACTIVO)
			{
				oRes.errorMessage = "El usuario se encuentra intactivo, debes activarlo desde tu cuenta correo registrada";
			}
			else
			{
				oResAuth.aplication = oAppBE;
				new EncryptionBE();
				string sUserPasswordBD = string.Empty;
				sUserPasswordBD = encryptDesEncrypt(2, resUsuario.Usuario.PASSWORD, long.Parse(_sIdApp)).VALOROUT.ToString();
				if (new Utils().ValidaPassword(oCredential.password, sUserPasswordBD))
				{
					CredentialRes.name = resUsuario.Usuario.NOMBRE;
					CredentialRes.idUser = resUsuario.Usuario.IDUSUARIO.ToString();
					switch (iTpoBusqueda)
					{
						case 1:
							CredentialRes.userName = resUsuario.Usuario.IDUSUARIO.ToString();
							break;
						case 2:
							CredentialRes.userName = resUsuario.Usuario.IDUSUARIOAPP;
							break;
						case 3:
							CredentialRes.userName = resUsuario.Usuario.USUARIO;
							break;
						default:
							CredentialRes.userName = resUsuario.Usuario.USUARIO;
							break;
					}
					CredentialRes.rolId = resUsuario.Usuario.IDUSUARIO.ToString();
					oResAuth.credencial = CredentialRes;
					oRes = CreaToken(oResAuth);
				}
				else
				{
					oRes.errorMessage = "El Password es incorrecto!";
				}
			}
			return oRes;
		}

		public ProcessResult CreaToken(resAuthenticate oResAuth)
		{
			ProcessResult oRes = new ProcessResult();
			TokenJwt oToken = new TokenJwt();
			try
			{
				int expireMinutes = oResAuth.aplication.jwtExpirationTime;
				string token = JwtManager.GenerateToken(oResAuth.credencial.userName, oResAuth.credencial.name, oResAuth.credencial.idUser.ToString(), oResAuth.credencial.rolId, oResAuth.aplication.jwtKey, expireMinutes);
				string tokenRefresh = JwtManager.GenerateTokenRefresh(oResAuth.credencial.userName, oResAuth.credencial.name, oResAuth.credencial.idUser.ToString(), oResAuth.credencial.rolId, "", oResAuth.aplication.jwtKey, expireMinutes);
				oToken.profileId = oResAuth.credencial.rolId;
				oToken.userId = oResAuth.credencial.userName;
				oToken.tokenId = token;
				oToken.tokenRefresh = tokenRefresh;
				oRes.flag = true;
				oRes.data = oToken;
				return oRes;
			}
			catch (Exception ex)
			{
				oRes.flag = false;
				oRes.errorMessage = ex.Message.ToString();
				return oRes;
			}
		}

		public void checkPermisoMethServ(long App, string sPasswordApp, string sMethodName, string sServiceName)
		{
			try
			{
				AplicacionBE PermisosApp = new AplicacionBE();
				EncryptDecryptSec CrypDecrypt = new EncryptDecryptSec();
				if (App == 0L || string.IsNullOrEmpty(sPasswordApp))
				{
					throw new SeguridadException("La aplicación no tiene acceso al servicio: " + sServiceName);
				}
				bool Permiso = false;
				PermisosApp = _securityServiceDA.checkPermisoXAplicacion(App, sPasswordApp);
				if (CrypDecrypt.DecryptString(PermisosApp.PASSWORD, "") == CrypDecrypt.DecryptString(sPasswordApp, ""))
				{
					Permiso = true;
				}
				if (!Permiso)
				{
					throw new SeguridadException("La aplicación no tiene acceso al servicio: " + sServiceName);
				}
				Permiso = false;
				new List<WCFMetodosBE>();
				if (_securityServiceDA.checkMetodoXApp(App, sServiceName, sMethodName).Count == 0)
				{
					throw new SeguridadException("La aplicación no tiene acceso al método: " + sMethodName);
				}
			}
			catch (SeguridadException ex)
			{
				throw new SeguridadException(ex.Message);
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message);
			}
		}

		public List<WCFMetodosBE> checkMetodoXApp(long App, string sServiceName, string sMethodName)
		{
			List<WCFMetodosBE> lstMetodos = new List<WCFMetodosBE>();
			try
			{
				return _securityServiceDA.checkMetodoXApp(App, sServiceName, sMethodName);
			}
			catch (SeguridadException ex)
			{
				throw new SeguridadException(ex.Message);
			}
			catch (Exception ex2)
			{
				throw new Exception(ex2.Message);
			}
		}

		public List<PermisosXObjetosBE> getObjetosXAppRolPage(long Rol, string Pagina, long App)
		{
			try
			{
				new List<PermisosXObjetosBE>();
				return _securityServiceDA.getObjetosXAppRolPage(Rol, Pagina, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<PermisoXElementosObjBE> getElementsObjectsXIdObj(long IdPermisosXObj, long App)
		{
			try
			{
				new List<PermisoXElementosObjBE>();
				return _securityServiceDA.getElementsObjectsXIdObj(IdPermisosXObj, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<PermisosXMenuBE> getMenuXAppRol(long Rol, long App)
		{
			try
			{
				new List<PermisosXMenuBE>();
				return _securityServiceDA.getMenuXAppRol(Rol, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public MenuVue getMenuVue(int idUsuario)
		{
			try
			{
				MenuVue oMenu = new MenuVue();
				List<ChildVue> oChild = new List<ChildVue>();
				new List<AppsUsuarioBE>();
				new List<RolesUserApp>();
				new List<PermisosXMenuBE>();
				new List<PermisoXSubmenuBE>();
				oMenu._name = "CSidebarNav";
				oChild.Add(new ChildVue
				{
					_name = "CSidebarNavItem",
					name = "Inicio",
					to = "/dashboard",
					icon = "cil-speedometer"
				});
				foreach (AppsUsuarioBE itemApp in _securityServiceDA.getAplicacionesUsuario(idUsuario))
				{
					List<string> aTitle = new List<string>();
					aTitle.Add(itemApp.DESCRIPCION);
					oChild.Add(new ChildVue
					{
						_name = "CSidebarNavTitle",
						_children = aTitle
					});
					foreach (PermisosXMenuBE itemMenu in _securityServiceDA.getMenuXAppRol(itemApp.IDROL, itemApp.IDAPLICACION))
					{
						if (itemMenu.URL == "#")
						{
							List<ItemVue> lstItemMenu = new List<ItemVue>();
							foreach (PermisoXSubmenuBE itemSubMenu in _securityServiceDA.getSubMenuXIdMenu(itemMenu.IDPERMISOSMENU, itemApp.IDAPLICACION))
							{
								ItemVue oItemVue = new ItemVue();
								oItemVue.name = itemSubMenu.NOMBRESUBMENU;
								oItemVue.to = itemSubMenu.URL;
								lstItemMenu.Add(oItemVue);
							}
							oChild.Add(new ChildVue
							{
								_name = "CSidebarNavDropdown",
								name = itemMenu.NOMBREMENU,
								route = itemMenu.TOOLTIP,
								icon = itemMenu.IMAGEN,
								items = lstItemMenu
							});
						}
						else
						{
							oChild.Add(new ChildVue
							{
								_name = "CSidebarNavItem",
								name = itemMenu.NOMBREMENU,
								to = itemMenu.URL,
								icon = itemMenu.IMAGEN
							});
						}
					}
				}
				oMenu._children = oChild;
				return oMenu;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<PermisoXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, long App)
		{
			try
			{
				new List<PermisoXSubmenuBE>();
				return _securityServiceDA.getSubMenuXIdMenu(IdPermisoMenu, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<PermisosXMenuBE> getMenuXAppRolAdmin(long Rol, long App)
		{
			try
			{
				new List<PermisosXMenuBE>();
				return _securityServiceDA.getMenuXAppRolAdmin(Rol, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<PermisoXSubmenuBE> getSubMenuXIdMenuAdmin(long IdPermisoMenu, long App)
		{
			try
			{
				new List<PermisoXSubmenuBE>();
				return _securityServiceDA.getSubMenuXIdMenuAdmin(IdPermisoMenu, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EncryptionBE encryptDesEncrypt(int Tipo, string Valor, long App)
		{
			try
			{
				EncryptDecryptSec CrypDecrypt = new EncryptDecryptSec();
				EncryptionBE Encriptacion = new EncryptionBE();
				if (Tipo == 1)
				{
					Encriptacion.VALORIN = Valor;
					Encriptacion.VALOROUT = CrypDecrypt.EncryptString(Valor, "");
				}
				else
				{
					Encriptacion.VALORIN = Valor;
					Encriptacion.VALOROUT = CrypDecrypt.DecryptString(Valor, "");
				}
				return Encriptacion;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<AplicacionBE> getAplicaciones(string idAplicacion, string txtbusqueda, long App)
		{
			try
			{
				new List<AplicacionBE>();
				return _securityServiceDA.getAplicaciones(idAplicacion, txtbusqueda, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addAplicacion(AplicacionBE Aplicacion, long App)
		{
			try
			{
				if (checkApp(Aplicacion.DESCRIPCION.ToString().ToUpper()))
				{
					throw new Exception("La Aplicacion ya existe.");
				}
				return _securityServiceDA.addAplicacion(Aplicacion, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool updAplicacion(AplicacionBE Aplicacion, long App)
		{
			try
			{
				return _securityServiceDA.updAplicacion(Aplicacion, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool updMenuxAppRol(long idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, long Orden, bool Activo, string idApp)
		{
			try
			{
				return _securityServiceDA.updMenuxAppRol(idMenu, Menu, Img, TpoObj, Url, Tool, Orden, Activo, idApp);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool updSubMenuxAppRol(long idPermisoMenu, long IdPermisoSubmenu, string SubMenu, string Img, string TpoObj, string Url, string Tool, long Orden, bool Activo, string App)
		{
			try
			{
				return _securityServiceDA.updSubMenuxAppRol(idPermisoMenu, IdPermisoSubmenu, SubMenu, Img, TpoObj, Url, Tool, Orden, Activo, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addRolxApp(string Rol, long App)
		{
			try
			{
				if (checkRol(Rol.ToString().ToUpper(), App))
				{
					throw new Exception("El Rol ya existe.");
				}
				return _securityServiceDA.addRolxApp(Rol.ToString().ToUpper(), App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addMetodo(List<WCFMetodosBE> lstMetodos, long IdApp)
		{
			try
			{
				return _securityServiceDA.addMetodo(lstMetodos, IdApp);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addServicio(string Servicio, long IdApp, bool Recurrente)
		{
			try
			{
				if (checkServicio(Servicio.ToString().ToUpper(), IdApp))
				{
					throw new Exception("El Servicio ya existe.");
				}
				return _securityServiceDA.addServicio(Servicio);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addMenuxAppRol(long Rol, long IdApp, string Menu, string Img, string Obj, string Url, string Tool, long Orden)
		{
			try
			{
				if (checkMenu(Menu, Rol, IdApp))
				{
					throw new Exception("El Servicio ya existe.");
				}
				return _securityServiceDA.addMenuxAppRol(Rol, IdApp, Menu, Img, Obj, Url, Tool, Orden);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addSubMenuxAppRol(long IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, long Orden)
		{
			try
			{
				if (checkSubMenu(SubMenu, IdSubMenu))
				{
					throw new Exception("El Servicio ya existe.");
				}
				return _securityServiceDA.addSubMenuxAppRol(IdSubMenu, SubMenu, Img, Obj, Url, Tool, Orden);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addPermisosxObjeto(long IdRol, string Pagina, string Obj, string TipoObj, string Tool)
		{
			try
			{
				return _securityServiceDA.addPermisosxObjeto(IdRol, Pagina, Obj, TipoObj, Tool);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addPermisosxElementoObjeto(long IdPermiosObj, string Elemento, string Tool)
		{
			try
			{
				return _securityServiceDA.addPermisosxElementoObjeto(IdPermiosObj, Elemento, Tool);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool delMenu(long idMenu, long App)
		{
			try
			{
				return _securityServiceDA.delMenu(idMenu, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool delSubMenu(long idSubMenu, long App)
		{
			try
			{
				return _securityServiceDA.delMenu(idSubMenu, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool checkApp(string App)
		{
			try
			{
				return _securityServiceDA.checkApp(App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool checkRol(string Rol, long App)
		{
			try
			{
				return _securityServiceDA.checkRol(Rol, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool checkMetodo(string Metodo, long IdApp, long Servicio)
		{
			try
			{
				return _securityServiceDA.checkMetodo(Metodo, IdApp, Servicio);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool checkServicio(string Servicio, long IdApp)
		{
			try
			{
				return _securityServiceDA.checkServicio(Servicio, IdApp);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool checkMenu(string Menu, long Rol, long IdApp)
		{
			try
			{
				return _securityServiceDA.checkMenuxAppRol(Menu, Rol, IdApp);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool checkSubMenu(string SubMenu, long PermisosMenu)
		{
			try
			{
				return _securityServiceDA.checkSubMenuxAppRol(SubMenu, PermisosMenu);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EncryptionBE encryptDecryptChain(int Tipo, string Valor, string Llave, long App)
		{
			try
			{
				EncryptDecryptSec CrypDecrypt = new EncryptDecryptSec();
				EncryptionBE Encriptacion = new EncryptionBE();
				if (Tipo == 1)
				{
					Encriptacion.VALORIN = Valor;
					Encriptacion.VALOROUT = CrypDecrypt.EncryptString(Valor, Llave);
				}
				else
				{
					Encriptacion.VALORIN = Valor;
					Encriptacion.VALOROUT = CrypDecrypt.DecryptString(Valor, Llave);
				}
				return Encriptacion;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EncryptionBE encryptDecryptOnBase(int Tipo, string Valor, long App)
		{
			try
			{
				EncryptDecryptSec CrypDecrypt = new EncryptDecryptSec();
				EncryptionBE Encriptacion = new EncryptionBE();
				if (Tipo == 1)
				{
					Encriptacion.VALORIN = Valor;
					Encriptacion.VALOROUT = CrypDecrypt.EncryptString(Valor, "867CEFA6144B306CA0D326");
				}
				else
				{
					Encriptacion.VALORIN = Valor;
					Encriptacion.VALOROUT = CrypDecrypt.DecryptString(Valor, "867CEFA6144B306CA0D326");
				}
				return Encriptacion;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EstacionesXAppBE> getEstacionesXAppComp(long IdApp, long App)
		{
			try
			{
				return _securityServiceDA.getEstacionesXAppComp(IdApp, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EstacionesXAppBE> getEstacionesXID(long IdEstacion, long App)
		{
			try
			{
				return _securityServiceDA.getEstacionesXID(IdEstacion, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public AplicacionBE getAppInfo(string xAppId)
		{
			try
			{
				return _securityServiceDA.getAppInfoDat(xAppId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}

}
