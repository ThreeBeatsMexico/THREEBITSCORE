using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PVLSECVB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Security;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security.Security;

namespace ThreeBits.Business.Security
{
    public class SecurityBR : _BaseService , ISecurityBR
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly ISecurityDA _dataAccess;

        public SecurityBR(ILogger<SecurityBR> logger,

            IConfiguration configuration,
            ISecurityDA seguridadDA)
        {
            _logger = logger;
            _configuration = configuration;
            _dataAccess = seguridadDA;

        }

        //public DataTable getAppInfo(string xAppId)
        //{
        //    try
        //    {
        //        //SecurityDA oSec = new SecurityDA();
        //        //return oSec.getAppInfoDat(xAppId);
        //        return _dataAccess.getAppInfoDat(xAppId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public void checkPermisoMethServ(Int64 App, string sPasswordApp, string sMethodName, string sServiceName)
        {
            try
            {
                AplicacionBE PermisosApp = new AplicacionBE();
                EncryptDecryptSecVB CrypDecrypt = new EncryptDecryptSecVB();

                bool Permiso = false;

                PermisosApp = _dataAccess.checkPermisoXAplicacion(App, sPasswordApp);
               // PermisosApp = SeguridadDA.checkPermisoXAplicacion(App, sPasswordApp);
                if (CrypDecrypt.DecryptString(PermisosApp.PASSWORD, "") == CrypDecrypt.DecryptString(sPasswordApp, "")) Permiso = true;
                ////Si sale negativo mandamos una excepcion controlada
                if (!Permiso) throw new SeguridadException("La aplicación no tiene acceso al servicio: " + sServiceName);

                Permiso = false;
                List<WCFMetodosBE> MetodosXApp = new List<WCFMetodosBE>();
                MetodosXApp = _dataAccess.checkMetodoXApp(App, sServiceName, sMethodName);
                if (MetodosXApp.Count == 0) throw new SeguridadException("La aplicación no tiene acceso al método: " + sMethodName);
            }
            catch (SeguridadException exCu)
            {
                throw new SeguridadException(exCu.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<WCFMetodosBE> checkMetodoXApp(Int64 App, string sServiceName, string sMethodName)
        {
            
            List<WCFMetodosBE> lstMetodos = new List<WCFMetodosBE>();
            try
            {
                DataTable dt = _dataAccess.checkMetodoXApp(App, sServiceName, sMethodName);
                string sDt = JsonConvert.SerializeObject(dt);
                lstMetodos = JsonConvert.DeserializeObject<List<WCFMetodosBE>>(sDt);
            }
            catch (SeguridadException exCu)
            {
                throw new SeguridadException(exCu.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstMetodos;
        }

        public List<PermisosXObjetosBE> getObjetosXAppRolPage(long Rol, string Pagina, Int64 App)
        {
            try
            {
                List<PermisosXObjetosBE> PermisoXObjetos = new List<PermisosXObjetosBE>();
                
                PermisoXObjetos = _dataAccess.getObjetosXAppRolPage(Rol, Pagina, App);
                return PermisoXObjetos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PermisoXElementosObjBE> getElementsObjectsXIdObj(long IdPermisosXObj, Int64 App)
        {
            try
            {
                List<PermisoXElementosObjBE> PermisoXElementosObj = new List<PermisoXElementosObjBE>();
                
                PermisoXElementosObj = _dataAccess.getElementsObjectsXIdObj(IdPermisosXObj, App);
                return PermisoXElementosObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PermisosXMenuBE> getMenuXAppRol(long Rol, Int64 App)
        {
            try
            {
                List<PermisosXMenuBE> PermisosXMenu = new List<PermisosXMenuBE>();
                
                PermisosXMenu = _dataAccess.getMenuXAppRol(Rol, App);
                return PermisosXMenu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PermisoXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, Int64 App)
        {
            try
            {
                List<PermisoXSubmenuBE> PermisosXSubmenu = new List<PermisoXSubmenuBE>();
                
                PermisosXSubmenu = _dataAccess.getSubMenuXIdMenu(IdPermisoMenu, App);
                return PermisosXSubmenu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PermisosXMenuBE> getMenuXAppRolAdmin(long Rol, Int64 App)
        {
            try
            {
                List<PermisosXMenuBE> PermisosXMenu = new List<PermisosXMenuBE>();
                
                PermisosXMenu = _dataAccess.getMenuXAppRolAdmin(Rol, App);
                return PermisosXMenu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PermisoXSubmenuBE> getSubMenuXIdMenuAdmin(long IdPermisoMenu, Int64 App)
        {
            try
            {
                List<PermisoXSubmenuBE> PermisosXSubmenu = new List<PermisoXSubmenuBE>();
                
                PermisosXSubmenu = _dataAccess.getSubMenuXIdMenuAdmin(IdPermisoMenu, App);
                return PermisosXSubmenu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EncryptionBE encryptDesEncrypt(int Tipo, string Valor, Int64 App)
        {
            try
            {
                EncryptDecryptSecVB CrypDecrypt = new EncryptDecryptSecVB();
                EncryptionBE Encriptacion = new EncryptionBE();
                if (Tipo == 1) ////Encrypta
                {
                    Encriptacion.VALORIN = Valor;
                    Encriptacion.VALOROUT = CrypDecrypt.EncryptString(Valor, "");
                }
                else ///Desencrypta
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

        public List<AplicacionBE> getAplicaciones(string idAplicacion, string txtbusqueda, Int64 App)
        {
            try
            {
                List<AplicacionBE> Aplicaciones = new List<AplicacionBE>();
                
                Aplicaciones = _dataAccess.getAplicaciones(idAplicacion, txtbusqueda, App);
                return Aplicaciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool addAplicacion(AplicacionBE Aplicacion, Int64 App)
        {
            try
            {
                

                bool bExistUsr = this.checkApp(Aplicacion.DESCRIPCION.ToString().ToUpper());
                if (bExistUsr) throw new Exception("La Aplicacion ya existe.");
                return _dataAccess.addAplicacion(Aplicacion, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updAplicacion(AplicacionBE Aplicacion, Int64 App)
        {
            try
            {
                
                //bool bExistUsr = checkApp(Aplicacion.DESCRIPCION.ToString().ToUpper());
                //if (!bExistUsr) throw new Exception("La Aplicacion ya existe.");
                return _dataAccess.updAplicacion(Aplicacion, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updMenuxAppRol(Int64 idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string idApp)
        {
            try
            {
                
                return _dataAccess.updMenuxAppRol(idMenu, Menu, Img, TpoObj, Url, Tool, Orden, Activo, idApp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool updSubMenuxAppRol(Int64 idPermisoMenu, Int64 IdPermisoSubmenu, string SubMenu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App)
        {
            try
            {
                
                return _dataAccess.updSubMenuxAppRol(idPermisoMenu, IdPermisoSubmenu, SubMenu, Img, TpoObj, Url, Tool, Orden, Activo, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public bool addRolxApp(string Rol, Int64 App)
        {
            try
            {
                

                bool bExistUsr = checkRol(Rol.ToString().ToUpper(), App);
                if (bExistUsr) throw new Exception("El Rol ya existe.");
                return _dataAccess.addRolxApp(Rol.ToString().ToUpper(), App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool addMetodo(List<WCFMetodosBE> lstMetodos, Int64 IdApp)
        {
            try
            {
                

                //[HVG][20012016][estas validaciones se estan realizando desde el front]
                //bool bExistUsr = checkMetodo(Metodo.ToString().ToUpper(), IdApp,Servicio);
                //if (bExistUsr) throw new Exception("El MEtodo ya existe.");
                return _dataAccess.addMetodo(lstMetodos, IdApp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addServicio(string Servicio, Int64 IdApp, bool Recurrente)
        {
            try
            {
                

                bool bExistUsr = checkServicio(Servicio.ToString().ToUpper(), IdApp);
                if (bExistUsr) throw new Exception("El Servicio ya existe.");
                return _dataAccess.addServicio(Servicio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addMenuxAppRol(Int64 Rol, Int64 IdApp, string Menu, string Img, string Obj, string Url, string Tool, Int64 Orden)
        {
            try
            {
                

                bool bExistUsr = checkMenu(Menu, Rol, IdApp);
                if (bExistUsr) throw new Exception("El Servicio ya existe.");
                return _dataAccess.addMenuxAppRol(Rol, IdApp, Menu, Img, Obj, Url, Tool, Orden);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addSubMenuxAppRol(Int64 IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, Int64 Orden)
        {
            try
            {
                

                bool bExistUsr = checkSubMenu(SubMenu, IdSubMenu);
                if (bExistUsr) throw new Exception("El Servicio ya existe.");
                return _dataAccess.addSubMenuxAppRol(IdSubMenu, SubMenu, Img, Obj, Url, Tool, Orden);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool addPermisosxObjeto(Int64 IdRol, string Pagina, string Obj, string TipoObj, string Tool)
        {
            try
            {
                


                return _dataAccess.addPermisosxObjeto(IdRol, Pagina, Obj, TipoObj, Tool);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addPermisosxElementoObjeto(Int64 IdPermiosObj, string Elemento, string Tool)
        {
            try
            {
                

                // bool bExistUsr = checkSubMenu(SubMenu, IdSubMenu);
                //if (bExistUsr) throw new Exception("El Servicio ya existe.");
                return _dataAccess.addPermisosxElementoObjeto(IdPermiosObj, Elemento, Tool);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool delMenu(Int64 idMenu, Int64 App)
        {
            try
            {
                
                return _dataAccess.delMenu(idMenu, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool delSubMenu(Int64 idSubMenu, Int64 App)
        {
            try
            {
                
                return _dataAccess.delSubMenu(idSubMenu, App);
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
                
                return _dataAccess.checkApp(App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool checkRol(string Rol, Int64 App)
        {
            try
            {
                
                return _dataAccess.checkRol(Rol, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool checkMetodo(string Metodo, Int64 IdApp, Int64 Servicio)
        {
            try
            {
                
                return _dataAccess.checkMetodo(Metodo, IdApp, Servicio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool checkServicio(string Servicio, Int64 IdApp)
        {
            try
            {
                
                return _dataAccess.checkServicio(Servicio, IdApp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool checkMenu(string Menu, Int64 Rol, Int64 IdApp)
        {
            try
            {
                
                return _dataAccess.checkMenuxAppRol(Menu, Rol, IdApp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool checkSubMenu(string SubMenu, Int64 PermisosMenu)
        {
            try
            {
                
                return _dataAccess.checkSubMenuxAppRol(SubMenu, PermisosMenu);
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
                EncryptDecryptSecVB CrypDecrypt = new EncryptDecryptSecVB();
                EncryptionBE Encriptacion = new EncryptionBE();
                if (Tipo == 1) ////Encrypta
                {
                    Encriptacion.VALORIN = Valor;
                    Encriptacion.VALOROUT = CrypDecrypt.EncryptString(Valor, Llave);
                }
                else ///Desencrypta
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


        public AplicacionBE getAppInfo(string xAppId)
        {
            try
            {
                AplicacionBE oRes = new AplicacionBE();     
                DataTable oResDT = _dataAccess.getAppInfoDat(xAppId);
                string sResDT = JsonConvert.SerializeObject(oResDT);
                oRes = JsonConvert.DeserializeObject<AplicacionBE>(sResDT); 
                return oRes;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }




    public class SeguridadException : Exception
    {
        public SeguridadException()
        {
        }
        public SeguridadException(string message)
            : base(message)
        {
        }
        public SeguridadException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}


