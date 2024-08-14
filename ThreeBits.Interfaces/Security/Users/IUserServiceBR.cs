using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.User;

namespace ThreeBits.Interfaces.Security.Users
{
	public interface IUserServiceBR
	{
		UsuariosBE addUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App);

		bool actDeactivateUsuario(ReglasBE Reglas, long App);

		bool updateUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App);

		bool addRolesXUsuario(ReglasBE Reglas, List<RolesXUsuarioBE> RolesXUsuario, long App);

		bool addUsuarioXAplicacion(ReglasBE Reglas, List<UsuarioXAppBE> lstUSuarioXApp, long App);

		DatosUsuarioBE getUsuarioFull(ReglasBE Reglas, long App);

		List<UsuariosBE> GetUsuarios(UsuariosBE item, long App);

		List<UsuariosBE> GetUsuario(UsuariosBE item, long App);

		List<RolesXUsuarioBE> GetRolesVsUser(ReglasBE Reglas, long App);

		List<RolesBE> getRolesXApp(ReglasBE Reglas, long App);

		bool checkUsrXApp(ReglasBE Reglas, long App);

		bool checkUsr(ReglasBE Reglas);

		List<UsuarioXAppBE> getAppXUsuario(ReglasBE Reglas, long App);

		List<EstacionesXAppBE> getEstacionesXApp(ReglasBE Reglas, long App);

		List<RelacionTipoUsuarioBE> getRelTipoUsuario(ReglasBE Reglas, long App);

		List<CatalogosBE> getCatSelection(int IdCatGeneral, int IdSubCatalogo, long App);

		bool updateRol(ReglasBE Reglas, RolesXUsuarioBE RolXUsuario, long App);

		List<DatosUsuarioBE> getUsuariosXRol(long IdRol, long App);

		UsuariosBE addUserAut(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App);

		string getUsrIdApp(long IDAPLICACION);
	}

}
