using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Entities.User;

namespace ThreeBits.Interfaces.Security.Security
{
    public interface ISecurityServiceBR
    {
        ProcessResult authenticate(Credential input);
        public ProcessResult CreaToken(resAuthenticate oResAuth);

        EncryptionBE encryptDesEncrypt(int Tipo, string Valor, Int64 App);
        AplicacionBE getAppInfo(string xAppId);

        void checkPermisoMethServ(Int64 App, string sPasswordApp, string sMethodName, string sServiceName);
        List<WCFMetodosBE> checkMetodoXApp(Int64 App, string sServiceName, string sMethodName);
        List<PermisosXObjetosBE> getObjetosXAppRolPage(long Rol, string Pagina, Int64 App);
        List<PermisoXElementosObjBE> getElementsObjectsXIdObj(long IdPermisosXObj, Int64 App);
        List<PermisosXMenuBE> getMenuXAppRol(long Rol, Int64 App);
        List<PermisoXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, Int64 App);
        List<PermisosXMenuBE> getMenuXAppRolAdmin(long Rol, Int64 App);
        List<PermisoXSubmenuBE> getSubMenuXIdMenuAdmin(long IdPermisoMenu, Int64 App);
        
        List<AplicacionBE> getAplicaciones(string idAplicacion, string txtbusqueda, Int64 App);
         bool addAplicacion(AplicacionBE Aplicacion, Int64 App);
        bool updAplicacion(AplicacionBE Aplicacion, Int64 App);
        bool updMenuxAppRol(Int64 idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string idApp);
        bool updSubMenuxAppRol(Int64 idPermisoMenu, Int64 IdPermisoSubmenu, string SubMenu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App);
        bool addRolxApp(string Rol, Int64 App);
        bool addMetodo(List<WCFMetodosBE> lstMetodos, Int64 IdApp);
        bool addServicio(string Servicio, Int64 IdApp, bool Recurrente);
        bool addMenuxAppRol(Int64 Rol, Int64 IdApp, string Menu, string Img, string Obj, string Url, string Tool, Int64 Orden);
        bool addSubMenuxAppRol(Int64 IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, Int64 Orden);
        bool addPermisosxObjeto(Int64 IdRol, string Pagina, string Obj, string TipoObj, string Tool);
        bool addPermisosxElementoObjeto(Int64 IdPermiosObj, string Elemento, string Tool);
        bool delMenu(Int64 idMenu, Int64 App);
        bool delSubMenu(Int64 idSubMenu, Int64 App);
        bool checkApp(string App);
        bool checkRol(string Rol, Int64 App);
        bool checkMetodo(string Metodo, Int64 IdApp, Int64 Servicio);
        bool checkServicio(string Servicio, Int64 IdApp);
        bool checkMenu(string Menu, Int64 Rol, Int64 IdApp);
        bool checkSubMenu(string SubMenu, Int64 PermisosMenu);
        EncryptionBE encryptDecryptChain(int Tipo, string Valor, string Llave, long App);
        //AplicacionBE getAppInfo(string xAppId);

        


    }
}
