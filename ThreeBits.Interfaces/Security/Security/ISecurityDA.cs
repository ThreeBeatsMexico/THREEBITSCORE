using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Security;

namespace ThreeBits.Interfaces.Security.Security
{
    public interface ISecurityDA
    {
        DataTable getAppInfoDat(string xAppId);
        DataTable checkPermisoXAplicacion(Int64 App, string sPasswordApp);
        DataTable checkMetodoXApp(Int64 App, string sServiceName, string sMethodName);
        DataTable getObjetosXAppRolPage(long Rol, string Pagina, Int64 App);
        DataTable getElementsObjectsXIdObj(long IdPermisosXObj, Int64 App);
        DataTable getMenuXAppRol(long Rol, Int64 App);
        DataTable getMenuXAppRolAdmin(long Rol, Int64 App);
        DataTable getSubMenuXIdMenu(long IdPermisoMenu, Int64 App);
        DataTable getSubMenuXIdMenuAdmin(long IdPermisoMenu, Int64 App);
        DataTable getAplicaciones(string idAplicacion, string txtBusqueda, Int64 App);
        DataTable addAplicacion(AplicacionBE Aplicacion, Int64 App);
        DataTable updAplicacion(AplicacionBE Aplicacion, Int64 App);
        DataTable updMenuxAppRol(Int64 idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App);
        DataTable updSubMenuxAppRol(Int64 idPermisoMenu, Int64 IdPermisoSubmenu, string SumMenu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App);
        DataTable addRolxApp(string Rol, Int64 App);
        DataTable addMetodo(List<WCFMetodosBE> lstMetodos, Int64 IdApp);
        DataTable addServicio(string Servicio);
        DataTable addSubMenuxAppRol(Int64 IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, Int64 Orden);
        DataTable addMenuxAppRol(Int64 Rol, Int64 App, string Menu, string Img, string Obj, string Url, string Tool, Int64 Orden);
        DataTable addPermisosxObjeto(Int64 Rol, string Pagina, string Obj, string TipoObjeto, string Tool);
        DataTable addPermisosxElementoObjeto(Int64 PermisoObj, string Elemento, string Tool);
        DataTable delMenu(Int64 idMenu, Int64 App);
        DataTable delSubMenu(Int64 idSubMenu, Int64 App);
        DataTable checkApp(string App);
        DataTable checkRol(string Rol, Int64 App);
        DataTable checkMetodo(string Metodo, Int64 IdApp, Int64 Servicio);
        DataTable checkServicio(string Servicio, Int64 IdApp);
        DataTable checkMenuxAppRol(string Menu, Int64 Rol, Int64 IdApp);
        DataTable checkSubMenuxAppRol(string SubMenu, Int64 PermisosMenu);
         //AplicacionBE getAppInfoDat(string xAppId);

    }
}
