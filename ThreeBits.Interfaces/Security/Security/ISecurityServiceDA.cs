using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Security;
using ThreeBits.Entities.User;

namespace ThreeBits.Interfaces.Security.Security
{
	public interface ISecurityServiceDA
	{
		AplicacionBE checkPermisoXAplicacion(long App, string sPasswordApp);

		List<WCFMetodosBE> checkMetodoXApp(long App, string sServiceName, string sMethodName);

		List<PermisosXObjetosBE> getObjetosXAppRolPage(long Rol, string Pagina, long App);

		List<PermisoXElementosObjBE> getElementsObjectsXIdObj(long IdPermisosXObj, long App);

		List<PermisosXMenuBE> getMenuXAppRol(long Rol, long App);

		List<PermisosXMenuBE> getMenuXAppRolAdmin(long Rol, long App);

		List<PermisoXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, long App);

		List<PermisoXSubmenuBE> getSubMenuXIdMenuAdmin(long IdPermisoMenu, long App);

		List<AplicacionBE> getAplicaciones(string idAplicacion, string txtBusqueda, long App);

		bool addAplicacion(AplicacionBE Aplicacion, long App);

		bool updAplicacion(AplicacionBE Aplicacion, long App);

		bool updMenuxAppRol(long idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, long Orden, bool Activo, string App);

		bool updSubMenuxAppRol(long idPermisoMenu, long IdPermisoSubmenu, string SumMenu, string Img, string TpoObj, string Url, string Tool, long Orden, bool Activo, string App);

		bool addRolxApp(string Rol, long App);

		bool addMetodo(List<WCFMetodosBE> lstMetodos, long IdApp);

		bool addServicio(string Servicio);

		bool addSubMenuxAppRol(long IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, long Orden);

		bool addMenuxAppRol(long Rol, long App, string Menu, string Img, string Obj, string Url, string Tool, long Orden);

		bool addPermisosxObjeto(long Rol, string Pagina, string Obj, string TipoObjeto, string Tool);

		bool addPermisosxElementoObjeto(long PermisoObj, string Elemento, string Tool);

		bool delMenu(long idMenu, long App);

		bool delSubMenu(long idSubMenu, long App);

		bool checkApp(string App);

		bool checkRol(string Rol, long App);

		bool checkMetodo(string Metodo, long IdApp, long Servicio);

		bool checkServicio(string Servicio, long IdApp);

		bool checkMenuxAppRol(string Menu, long Rol, long IdApp);

		bool checkSubMenuxAppRol(string SubMenu, long PermisosMenu);

		List<EstacionesXAppBE> getEstacionesXAppComp(long IdApp, long App);

		List<EstacionesXAppBE> getEstacionesXID(long IdEstacion, long App);

		AplicacionBE getAppInfoDat(string xAppId);

		List<AppsUsuarioBE> getAplicacionesUsuario(int idUsuario);

		List<RolesUserApp> getRolesUserApp(string idUsuario, int iBusqueda, long idApp);
	}

}
