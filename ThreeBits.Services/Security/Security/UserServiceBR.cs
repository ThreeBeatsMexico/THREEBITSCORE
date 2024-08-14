using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security.Users;

namespace ThreeBits.Services.Security.Security
{
	public class UserServiceBR : _BaseService, IUserServiceBR
	{
		private readonly ILogger _logger;

		private readonly IUserServiceDA _userServiceDA;

		public UserServiceBR(ILogger<SecurityServiceBR> logger, IUserServiceDA userServiceDA)
		{
			_logger = logger;
			_userServiceDA = userServiceDA;
		}

		public UsuariosBE addUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App)
		{
			new UsuariosBE();
			try
			{
				new ReglasBE();
				if (checkUsrXApp(Reglas, App))
				{
					throw new Exception("El usuario ya se encuentra agregado.");
				}
				return _userServiceDA.addUsuario(Reglas, Usuario, Domicilios, Contactos, RolesXUsuario, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool actDeactivateUsuario(ReglasBE Reglas, long App)
		{
			try
			{
				return _userServiceDA.actDeactivateUsuario(Reglas, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool updateUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App)
		{
			try
			{
				return _userServiceDA.updateUsuario(Reglas, Usuario, Domicilios, Contactos, RolesXUsuario, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addRolesXUsuario(ReglasBE Reglas, List<RolesXUsuarioBE> RolesXUsuario, long App)
		{
			try
			{
				if (!checkUsrXApp(Reglas, App))
				{
					throw new Exception("El usuario no pertenece a la aplicación o no existe.");
				}
				List<RolesBE> RolesXApp = _userServiceDA.getRolesXApp(Reglas, App);
				bool bFlagExist = false;
				foreach (RolesXUsuarioBE s in RolesXUsuario)
				{
					bFlagExist = false;
					foreach (RolesBE RolXApp in RolesXApp)
					{
						if (s.IDROL == RolXApp.IDROL)
						{
							bFlagExist = true;
							break;
						}
					}
					if (!bFlagExist)
					{
						throw new Exception("El rol " + s.IDROL + " no pertenece a la aplicación o no existe.");
					}
				}
				return _userServiceDA.addRolesXUsuario(Reglas, RolesXUsuario, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool addUsuarioXAplicacion(ReglasBE Reglas, List<UsuarioXAppBE> lstUSuarioXApp, long App)
		{
			try
			{
				return _userServiceDA.addUsuarioXAplicacion(Reglas, lstUSuarioXApp, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DatosUsuarioBE getUsuarioFull(ReglasBE Reglas, long App)
		{
			new DatosUsuarioBE();
			try
			{
				return _userServiceDA.GetUsuarioFull(Reglas, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<UsuariosBE> GetUsuarios(UsuariosBE item, long App)
		{
			new List<UsuariosBE>();
			return _userServiceDA.GetUsuarios(item, App);
		}

		public List<UsuariosBE> GetUsuario(UsuariosBE item, long App)
		{
			new List<UsuariosBE>();
			return _userServiceDA.GetUsuario(item, App);
		}

		public List<RolesXUsuarioBE> GetRolesVsUser(ReglasBE Reglas, long App)
		{
			new List<RolesXUsuarioBE>();
			return _userServiceDA.GetRolesVsUser(Reglas, App);
		}

		public List<RolesBE> getRolesXApp(ReglasBE Reglas, long App)
		{
			try
			{
				return _userServiceDA.getRolesXApp(Reglas, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool checkUsrXApp(ReglasBE Reglas, long App)
		{
			try
			{
				return _userServiceDA.checkUsrXApp(Reglas, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool checkUsr(ReglasBE Reglas)
		{
			try
			{
				return _userServiceDA.checkUsr(Reglas);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<UsuarioXAppBE> getAppXUsuario(ReglasBE Reglas, long App)
		{
			try
			{
				return _userServiceDA.getAppXUsuario(Reglas, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EstacionesXAppBE> getEstacionesXApp(ReglasBE Reglas, long App)
		{
			try
			{
				return _userServiceDA.getEstacionesXApp(Reglas, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<RelacionTipoUsuarioBE> getRelTipoUsuario(ReglasBE Reglas, long App)
		{
			return new List<RelacionTipoUsuarioBE>();
		}

		public List<CatalogosBE> getCatSelection(int IdCatGeneral, int IdSubCatalogo, long App)
		{
			try
			{
				return _userServiceDA.getCatSelection(IdCatGeneral, IdSubCatalogo, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool updateRol(ReglasBE Reglas, RolesXUsuarioBE RolXUsuario, long App)
		{
			try
			{
				List<RolesBE> rolesXApp = getRolesXApp(Reglas, App);
				bool bFlagExist = false;
				bFlagExist = false;
				foreach (RolesBE RolXApp in rolesXApp)
				{
					if (RolXUsuario.IDROL == RolXApp.IDROL)
					{
						bFlagExist = true;
						break;
					}
				}
				if (!bFlagExist)
				{
					throw new Exception("El rol " + RolXUsuario.IDROL + " no pertenece a la aplicación o no existe.");
				}
				return _userServiceDA.updateRol(Reglas, RolXUsuario, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<DatosUsuarioBE> getUsuariosXRol(long IdRol, long App)
		{
			new List<DatosUsuarioBE>();
			try
			{
				return _userServiceDA.getUsuariosXRol(IdRol, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public UsuariosBE addUserAut(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App)
		{
			new UsuariosBE();
			try
			{
				bool bExistUsr = true;
				ReglasBE ReglasInt = new ReglasBE();
				ReglasInt.USUARIO = Usuario.USUARIO;
				ReglasInt.TIPOBUSQUEDA = 3;
				ReglasInt.IDAPP = Usuario.IDAPLICACION;
				if (checkUsr(ReglasInt))
				{
					throw new Exception("El correo para la cuenta ya ha sido utilizado con anterioridad.");
				}
				List<RolesBE> RolesXApp = getRolesXApp(Reglas, App);
				bool bFlagExist = false;
				foreach (RolesXUsuarioBE s in RolesXUsuario)
				{
					bFlagExist = false;
					foreach (RolesBE RolXApp in RolesXApp)
					{
						if (s.IDROL == RolXApp.IDROL)
						{
							bFlagExist = true;
							break;
						}
					}
					if (!bFlagExist)
					{
						throw new Exception("El rol " + s.IDROL + " no pertenece a la aplicación o no existe.");
					}
				}
				bExistUsr = true;
				for (int i = 1; i < 5; i++)
				{
					Usuario.IDUSUARIOAPP = getUsrIdApp(Usuario.IDAPLICACION);
					ReglasInt.USUARIO = Usuario.IDUSUARIOAPP;
					ReglasInt.TIPOBUSQUEDA = 2;
					bExistUsr = checkUsr(ReglasInt);
					if (!bExistUsr)
					{
						break;
					}
				}
				if (bExistUsr)
				{
					throw new Exception("El numero de usuario ya se encuentra asignado, intentelo mas tarde.");
				}
				return _userServiceDA.addUsuario(Reglas, Usuario, Domicilios, Contactos, RolesXUsuario, App);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public string getUsrIdApp(long IDAPLICACION)
		{
			try
			{
				return _userServiceDA.getUsrIdApp(IDAPLICACION);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}

}
