using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;

namespace ThreeBits.Interfaces.Security.Security
{
	public interface ISecurityServiceBR
	{
		ProcessResult authenticate(Credential input);

		ProcessResult CreaToken(resAuthenticate oResAuth);

		EncryptionBE encryptDesEncrypt(int Tipo, string Valor, long App);

		AplicacionBE getAppInfo(string xAppId);

		void checkPermisoMethServ(long App, string sPasswordApp, string sMethodName, string sServiceName);

		List<WCFMetodosBE> checkMetodoXApp(long App, string sServiceName, string sMethodName);

		List<PermisosXObjetosBE> getObjetosXAppRolPage(long Rol, string Pagina, long App);

		List<PermisoXElementosObjBE> getElementsObjectsXIdObj(long IdPermisosXObj, long App);

		List<PermisosXMenuBE> getMenuXAppRol(long Rol, long App);

		List<PermisoXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, long App);

		List<PermisosXMenuBE> getMenuXAppRolAdmin(long Rol, long App);

		List<PermisoXSubmenuBE> getSubMenuXIdMenuAdmin(long IdPermisoMenu, long App);

		List<AplicacionBE> getAplicaciones(string idAplicacion, string txtbusqueda, long App);

		bool addAplicacion(AplicacionBE Aplicacion, long App);

		bool updAplicacion(AplicacionBE Aplicacion, long App);

		bool updMenuxAppRol(long idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, long Orden, bool Activo, string idApp);

		bool updSubMenuxAppRol(long idPermisoMenu, long IdPermisoSubmenu, string SubMenu, string Img, string TpoObj, string Url, string Tool, long Orden, bool Activo, string App);

		bool addRolxApp(string Rol, long App);

		bool addMetodo(List<WCFMetodosBE> lstMetodos, long IdApp);

		bool addServicio(string Servicio, long IdApp, bool Recurrente);

		bool addMenuxAppRol(long Rol, long IdApp, string Menu, string Img, string Obj, string Url, string Tool, long Orden);

		bool addSubMenuxAppRol(long IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, long Orden);

		bool addPermisosxObjeto(long IdRol, string Pagina, string Obj, string TipoObj, string Tool);

		bool addPermisosxElementoObjeto(long IdPermiosObj, string Elemento, string Tool);

		bool delMenu(long idMenu, long App);

		bool delSubMenu(long idSubMenu, long App);

		bool checkApp(string App);

		bool checkRol(string Rol, long App);

		bool checkMetodo(string Metodo, long IdApp, long Servicio);

		bool checkServicio(string Servicio, long IdApp);

		bool checkMenu(string Menu, long Rol, long IdApp);

		bool checkSubMenu(string SubMenu, long PermisosMenu);

		EncryptionBE encryptDecryptChain(int Tipo, string Valor, string Llave, long App);
	}

}
