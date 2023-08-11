using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.Security.Security;
using ThreeBits.Shared;
using ThreeBits.Business;
using ThreeBits.Business.Security.Security;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security.Users;
using Microsoft.Extensions.Configuration;

namespace ThreeBits.Services.Security
{
    public class SecurityServiceBR : _BaseService, ISecurityServiceBR
    {
        private readonly ILogger _logger;
        private readonly ISecurityServiceDA _securityServiceDA;
        private readonly IUserServiceBR _userServiceBR;
        private readonly IConfiguration _configuration;
        public string _sIdApp;

        public SecurityServiceBR(ILogger<SecurityServiceBR> logger, ISecurityServiceDA securityServiceDA, IUserServiceBR userServiceBR, IConfiguration configuration)
        {
            _logger = logger;
            _securityServiceDA = securityServiceDA;
            _userServiceBR = userServiceBR;
            _configuration = configuration;
            _sIdApp = _configuration["TBSettings:IdApp"];
        }

        AplicacionBE oAppBE = new AplicacionBE();
        public ProcessResult authenticate(Credential oCredential)
        {
            Credential CredentialRes = new Credential();
            resAuthenticate oResAuth = new resAuthenticate();
            ProcessResult oRes = new ProcessResult();
            ReglasBE reglas = new ReglasBE();
            DatosUsuarioBE resUsuario = new DatosUsuarioBE();
            int iTpoBusqueda = oCredential.tipoBusqueda.HasValue ? Convert.ToInt32(oCredential.tipoBusqueda) : 3;
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
                else if (resUsuario.Usuario.ACTIVO == false)
                {
                    oRes.errorMessage = "El usuario se encuentra intactivo, debes activarlo desde tu cuenta correo registrada";
                }
                else
                {
                    oResAuth.aplication = oAppBE;
                    EncryptionBE ResDecrypt = new EncryptionBE();
                    string sUserPasswordBD = string.Empty;
                    //// SE AGREGA VALIDAION PARA NO ENCRIPTAR PASSWORD DE AVATAR
                    //if (oCredential.xAppId.ToString() == "9A53FEF3571E4635")
                    //    oCredential.encriptaPassword = true;


                    //if (!oCredential.encriptaPassword)
                    //{
                    ResDecrypt = encryptDesEncrypt(2, resUsuario.Usuario.PASSWORD, long.Parse(_sIdApp));
                    sUserPasswordBD = ResDecrypt.VALOROUT.ToString();
                    //}
                    //else
                    //{
                    //    sUserPasswordBD = resUsuario.Usuario.PASSWORD;
                    //}

                    Utils oUtils = new Utils();
                    if (oUtils.ValidaPassword(oCredential.password, sUserPasswordBD))
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
                    else { oRes.errorMessage = "El Password es incorrecto!"; }
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
            }
            catch (Exception ex)
            {
                oRes.flag = false;
                oRes.errorMessage = ex.Message.ToString();
            }
            return oRes;
        }


        public void checkPermisoMethServ(Int64 App, string sPasswordApp, string sMethodName, string sServiceName)
        {
            try
            {
               
                AplicacionBE PermisosApp = new AplicacionBE();
                EncryptDecryptSec CrypDecrypt = new EncryptDecryptSec();

                if (App == 0 || string.IsNullOrEmpty(sPasswordApp)) throw new SeguridadException("La aplicación no tiene acceso al servicio: " + sServiceName);

                bool Permiso = false;
                PermisosApp = _securityServiceDA.checkPermisoXAplicacion(App, sPasswordApp);
                if (CrypDecrypt.DecryptString(PermisosApp.PASSWORD, "") == CrypDecrypt.DecryptString(sPasswordApp, "")) Permiso = true;
                ////Si sale negativo mandamos una excepcion controlada
                if (!Permiso) throw new SeguridadException("La aplicación no tiene acceso al servicio: " + sServiceName);

                Permiso = false;
                List<WCFMetodosBE> MetodosXApp = new List<WCFMetodosBE>();
                MetodosXApp = _securityServiceDA.checkMetodoXApp(App, sServiceName, sMethodName);
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
                lstMetodos = _securityServiceDA.checkMetodoXApp(App, sServiceName, sMethodName);
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
                
                PermisoXObjetos = _securityServiceDA.getObjetosXAppRolPage(Rol, Pagina, App);
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
                
                PermisoXElementosObj = _securityServiceDA.getElementsObjectsXIdObj(IdPermisosXObj, App);
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
                
                PermisosXMenu = _securityServiceDA.getMenuXAppRol(Rol, App);
                return PermisosXMenu;
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
                List<AppsUsuarioBE> lstApps = new List<AppsUsuarioBE>();
                List<RolesUserApp> lstRoles = new List<RolesUserApp>();
                List<PermisosXMenuBE> lstMenus = new List<PermisosXMenuBE>();
                List<PermisoXSubmenuBE> lstSubMenus = new List<PermisoXSubmenuBE>();

                
                oMenu._name = "CSidebarNav";
                oChild.Add(new ChildVue()
                {
                    _name = "CSidebarNavItem",
                    name = "Inicio",
                    to = "/dashboard",
                    icon = "cil-speedometer"
                });
                lstApps = _securityServiceDA.getAplicacionesUsuario(idUsuario);
                foreach (var itemApp in lstApps)
                {
                    List<string> aTitle = new List<string>();
                    aTitle.Add(itemApp.DESCRIPCION);
                    oChild.Add(new ChildVue()
                    {
                        _name = "CSidebarNavTitle",
                        _children = aTitle
                    });

                    lstMenus = _securityServiceDA.getMenuXAppRol(itemApp.IDROL, itemApp.IDAPLICACION);
                    foreach (var itemMenu in lstMenus)
                    {
                        if (itemMenu.URL == "#")
                        {
                            List<ItemVue> lstItemMenu = new List<ItemVue>();
                            lstSubMenus = _securityServiceDA.getSubMenuXIdMenu(itemMenu.IDPERMISOSMENU, itemApp.IDAPLICACION);
                            foreach (var itemSubMenu in lstSubMenus)
                            {
                                ItemVue oItemVue = new ItemVue();
                                oItemVue.name = itemSubMenu.NOMBRESUBMENU;
                                oItemVue.to = itemSubMenu.URL;
                                lstItemMenu.Add(oItemVue);

                            }
                            oChild.Add(new ChildVue()
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
                            oChild.Add(new ChildVue()
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


        public List<PermisoXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, Int64 App)
        {
            try
            {
                List<PermisoXSubmenuBE> PermisosXSubmenu = new List<PermisoXSubmenuBE>();
                
                PermisosXSubmenu = _securityServiceDA.getSubMenuXIdMenu(IdPermisoMenu, App);
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
                
                PermisosXMenu = _securityServiceDA.getMenuXAppRolAdmin(Rol, App);
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
                
                PermisosXSubmenu = _securityServiceDA.getSubMenuXIdMenuAdmin(IdPermisoMenu, App);
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
                EncryptDecryptSec CrypDecrypt = new EncryptDecryptSec();
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
                
                Aplicaciones = _securityServiceDA.getAplicaciones(idAplicacion, txtbusqueda, App);
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
                

                bool bExistUsr = checkApp(Aplicacion.DESCRIPCION.ToString().ToUpper());
                if (bExistUsr) throw new Exception("La Aplicacion ya existe.");
                return _securityServiceDA.addAplicacion(Aplicacion, App);
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
                return _securityServiceDA.updAplicacion(Aplicacion, App);
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
                
                return _securityServiceDA.updMenuxAppRol(idMenu, Menu, Img, TpoObj, Url, Tool, Orden, Activo, idApp);
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
                
                return _securityServiceDA.updSubMenuxAppRol(idPermisoMenu, IdPermisoSubmenu, SubMenu, Img, TpoObj, Url, Tool, Orden, Activo, App);
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
                return _securityServiceDA.addRolxApp(Rol.ToString().ToUpper(), App);
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
                return _securityServiceDA.addMetodo(lstMetodos, IdApp);
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
                return _securityServiceDA.addServicio(Servicio);
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
                return _securityServiceDA.addMenuxAppRol(Rol, IdApp, Menu, Img, Obj, Url, Tool, Orden);
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
                return _securityServiceDA.addSubMenuxAppRol(IdSubMenu, SubMenu, Img, Obj, Url, Tool, Orden);
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
                


                return _securityServiceDA.addPermisosxObjeto(IdRol, Pagina, Obj, TipoObj, Tool);
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
                return _securityServiceDA.addPermisosxElementoObjeto(IdPermiosObj, Elemento, Tool);
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
                
                return _securityServiceDA.delMenu(idMenu, App);
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

        public bool checkRol(string Rol, Int64 App)
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

        public bool checkMetodo(string Metodo, Int64 IdApp, Int64 Servicio)
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

        public bool checkServicio(string Servicio, Int64 IdApp)
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

        public bool checkMenu(string Menu, Int64 Rol, Int64 IdApp)
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

        public bool checkSubMenu(string SubMenu, Int64 PermisosMenu)
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

        public EncryptionBE encryptDecryptOnBase(int Tipo, string Valor, long App)
        {
            try
            {
                EncryptDecryptSec CrypDecrypt = new EncryptDecryptSec();
                EncryptionBE Encriptacion = new EncryptionBE();
                if (Tipo == 1) ////Encrypta
                {
                    Encriptacion.VALORIN = Valor;
                    Encriptacion.VALOROUT = CrypDecrypt.EncryptString(Valor, "867CEFA6144B306CA0D326");
                }
                else ///Desencrypta
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

        public List<EstacionesXAppBE> getEstacionesXAppComp(Int64 IdApp, long App)
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
