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
        UsuariosBE addUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, Int64 App);
        bool actDeactivateUsuario(ReglasBE Reglas, Int64 App);
        bool updateUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, Int64 App);
        bool addRolesXUsuario(ReglasBE Reglas, List<RolesXUsuarioBE> RolesXUsuario, long App);
        bool addUsuarioXAplicacion(ReglasBE Reglas, List<UsuarioXAppBE> lstUSuarioXApp, Int64 App);
        DatosUsuarioBE getUsuarioFull(ReglasBE Reglas, Int64 App);
        List<UsuariosBE> GetUsuarios(UsuariosBE item, Int64 App);
        List<UsuariosBE> GetUsuario(UsuariosBE item, Int64 App);
        List<RolesXUsuarioBE> GetRolesVsUser(ReglasBE Reglas, Int64 App);
        List<RolesBE> getRolesXApp(ReglasBE Reglas, Int64 App);
        bool checkUsrXApp(ReglasBE Reglas, Int64 App);
        bool checkUsr(ReglasBE Reglas);
        List<UsuarioXAppBE> getAppXUsuario(ReglasBE Reglas, Int64 App);
        List<EstacionesXAppBE> getEstacionesXApp(ReglasBE Reglas, Int64 App);
        List<RelacionTipoUsuarioBE> getRelTipoUsuario(ReglasBE Reglas, Int64 App);
        List<CatalogosBE> getCatSelection(int IdCatGeneral, int IdSubCatalogo, Int64 App);
        bool updateRol(ReglasBE Reglas, RolesXUsuarioBE RolXUsuario, long App);
        List<DatosUsuarioBE> getUsuariosXRol(long IdRol, long App);
        UsuariosBE addUserAut(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App);
        string getUsrIdApp(Int64 IDAPLICACION);
        
    }
}
