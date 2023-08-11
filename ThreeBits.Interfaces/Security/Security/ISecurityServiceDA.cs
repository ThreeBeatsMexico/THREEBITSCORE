using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Security;
using ThreeBits.Entities.User;

namespace ThreeBits.Interfaces.Security.Security
{
    public interface ISecurityServiceDA
    {
        public AplicacionBE checkPermisoXAplicacion(Int64 App, string sPasswordApp);
        public List<WCFMetodosBE> checkMetodoXApp(Int64 App, string sServiceName, string sMethodName);
        public List<PermisosXObjetosBE> getObjetosXAppRolPage(long Rol, string Pagina, Int64 App);
        public List<PermisoXElementosObjBE> getElementsObjectsXIdObj(long IdPermisosXObj, Int64 App);
        public List<PermisosXMenuBE> getMenuXAppRol(long Rol, Int64 App);
        public List<PermisosXMenuBE> getMenuXAppRolAdmin(long Rol, Int64 App);
        public List<PermisoXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, Int64 App);
        public List<PermisoXSubmenuBE> getSubMenuXIdMenuAdmin(long IdPermisoMenu, Int64 App);
        public List<AplicacionBE> getAplicaciones(string idAplicacion, string txtBusqueda, Int64 App);
        public bool addAplicacion(AplicacionBE Aplicacion, Int64 App);
        public bool updAplicacion(AplicacionBE Aplicacion, Int64 App);
        public bool updMenuxAppRol(Int64 idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App);
        public bool updSubMenuxAppRol(Int64 idPermisoMenu, Int64 IdPermisoSubmenu, string SumMenu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App);
        public bool addRolxApp(string Rol, Int64 App);
        public bool addMetodo(List<WCFMetodosBE> lstMetodos, Int64 IdApp);
        public bool addServicio(string Servicio);
        public bool addSubMenuxAppRol(Int64 IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, Int64 Orden);
        public bool addMenuxAppRol(Int64 Rol, Int64 App, string Menu, string Img, string Obj, string Url, string Tool, Int64 Orden);
        public bool addPermisosxObjeto(Int64 Rol, string Pagina, string Obj, string TipoObjeto, string Tool);
        public bool addPermisosxElementoObjeto(Int64 PermisoObj, string Elemento, string Tool);
        public bool delMenu(Int64 idMenu, Int64 App);
        public bool delSubMenu(Int64 idSubMenu, Int64 App);
        public bool checkApp(string App);
        public bool checkRol(string Rol, Int64 App);
        public bool checkMetodo(string Metodo, Int64 IdApp, Int64 Servicio);
        public bool checkServicio(string Servicio, Int64 IdApp);
        public bool checkMenuxAppRol(string Menu, Int64 Rol, Int64 IdApp);
        public bool checkSubMenuxAppRol(string SubMenu, Int64 PermisosMenu);
        public List<EstacionesXAppBE> getEstacionesXAppComp(Int64 IdApp, long App);
        public List<EstacionesXAppBE> getEstacionesXID(long IdEstacion, long App);
        public AplicacionBE getAppInfoDat(string xAppId);
        public List<AppsUsuarioBE> getAplicacionesUsuario(int idUsuario);
        public List<RolesUserApp> getRolesUserApp(string idUsuario, int iBusqueda, Int64 idApp);
    }
}
