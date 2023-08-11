using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security.Common;
using ThreeBits.Interfaces.Security.Security;

namespace ThreeBits.Services.Security
{
    public class SecurityServiceDA : SqlDataContext, ISecurityServiceDA
    {

        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly ICommonServiceDA _securityCommon;

        public SecurityServiceDA(ILogger<SecurityServiceDA> logger,

            IConfiguration configuration, ICommonServiceDA securityCommonDA)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            _securityCommon = securityCommonDA;
        }

        public AplicacionBE checkPermisoXAplicacion(Int64 App, string sPasswordApp)
        {
            AplicacionBE PermisosXApp = new AplicacionBE();
            try
            {
                var dbCommand = new SqlCommand("spFront_getPermisoXApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
                
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        PermisosXApp.IDAPLICACION = long.Parse(row["IDAPLICACION"].ToString());
                        PermisosXApp.DESCRIPCION = row["DESCRIPCION"].ToString();
                        PermisosXApp.PASSWORD = row["PASSWORD"].ToString();
                        PermisosXApp.ACTIVO = row["ACTIVO"] == null ? false : Boolean.Parse(row["ACTIVO"].ToString());
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);



                            return PermisosXApp;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<WCFMetodosBE> checkMetodoXApp(Int64 App, string sServiceName, string sMethodName)
        {
            
            List<WCFMetodosBE> MetodosXApp = new List<WCFMetodosBE>();
            try
            {
                var dbCommand = new SqlCommand("spFront_getMetodoXApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
                dbCommand.Parameters.Add("@SERVICENAME", SqlDbType.VarChar).Value = sServiceName;
                dbCommand.Parameters.Add("@METHODNAME", SqlDbType.VarChar).Value = sMethodName;
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        WCFMetodosBE MetodosBE = new WCFMetodosBE();
                        MetodosBE.IDMETODOS = long.Parse(row["IDMETODOS"].ToString());
                        MetodosBE.IDAPLICACION = long.Parse(row["IDAPLICACION"].ToString());
                        MetodosBE.IDSERVICIOS = long.Parse(row["IDSERVICIOS"].ToString());
                        MetodosBE.NOMBREMETODO = row["NOMBREMETODO"].ToString();
                        MetodosBE.RECURRENTE = Convert.ToBoolean(row["RECURRENTE"].ToString());
                        MetodosBE.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        MetodosXApp.Add(MetodosBE);
                    }
                }
                else throw new DbDataContextException(dbError);
                
                return MetodosXApp;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisosXObjetosBE> getObjetosXAppRolPage(long Rol, string Pagina, Int64 App)
        {
            
            List<PermisosXObjetosBE> PermisoXObjetos = new List<PermisosXObjetosBE>();
            try
            {
                Int64 iApp = App;
                var dbCommand = new SqlCommand("spFront_getObjetosXAppRolPage")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
                dbCommand.Parameters.Add("@IdRol", SqlDbType.BigInt).Value = Rol;
                dbCommand.Parameters.Add("@Pagina", SqlDbType.VarChar).Value = Pagina;
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        PermisosXObjetosBE Permiso = new PermisosXObjetosBE();
                        Permiso.IDPERMISOSOBJ = long.Parse(row["IDPERMISOSOBJ"].ToString());
                        Permiso.IDROL = long.Parse(row["IDROL"].ToString());
                        Permiso.PAGINA = row["PAGINA"].ToString();
                        Permiso.NOMBREOBJETO = row["NOMBREOBJETO"].ToString();
                        Permiso.TIPOOBJETO = row["TIPOOBJETO"].ToString();
                        Permiso.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        PermisoXObjetos.Add(Permiso);
                    }
                }
                else throw new DbDataContextException(dbError);


               
                return PermisoXObjetos;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisoXElementosObjBE> getElementsObjectsXIdObj(long IdPermisosXObj, Int64 App)
        {
            
            List<PermisoXElementosObjBE> PermisoXElementosObj = new List<PermisoXElementosObjBE>();
            try
            {
                Int64 iApp = App;
                var dbCommand = new SqlCommand("spFront_getElementsObjectsXIdObj")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDELEMENTOSXOBJ", SqlDbType.BigInt).Value = IdPermisosXObj;
              
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        PermisoXElementosObjBE Permiso = new PermisoXElementosObjBE();
                        Permiso.IDELEMENTOSXOBJ = long.Parse(row["IDELEMENTOSXOBJ"].ToString());
                        Permiso.IDPERMISOSOBJ = long.Parse(row["IDPERMISOSOBJ"].ToString());
                        Permiso.ELEMENTO = row["ELEMENTO"].ToString();
                        Permiso.TOOLTIP = row["TOOLTIP"].ToString();
                        Permiso.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        PermisoXElementosObj.Add(Permiso);
                    }
                }
                else throw new DbDataContextException(dbError);
                                return PermisoXElementosObj;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisosXMenuBE> getMenuXAppRol(long Rol, Int64 App)
        {
            
            List<PermisosXMenuBE> PermisosXMenu = new List<PermisosXMenuBE>();
            try
            {
                Int64 iApp = App;

                var dbCommand = new SqlCommand("spFront_getMenusXAppRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
                dbCommand.Parameters.Add("@IdRol", SqlDbType.BigInt).Value = Rol;



                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        PermisosXMenuBE Permiso = new PermisosXMenuBE();
                        Permiso.IDPERMISOSMENU = long.Parse(row["IDPERMISOSMENU"].ToString());
                        Permiso.IDROL = long.Parse(row["IDROL"].ToString());
                        Permiso.NOMBREMENU = row["NOMBREMENU"].ToString();
                        Permiso.IMAGEN = row["IMAGEN"].ToString();
                        Permiso.TIPOOBJETO = row["TIPOOBJETO"].ToString();
                        Permiso.URL = row["URL"].ToString();
                        Permiso.TOOLTIP = row["TOOLTIP"].ToString();
                        Permiso.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        Permiso.ORDENMENU = Convert.ToInt32(row["ORDEN"].ToString());
                        PermisosXMenu.Add(Permiso);
                    }
                }
                else throw new DbDataContextException(dbError);
               
                return PermisosXMenu;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisosXMenuBE> getMenuXAppRolAdmin(long Rol, Int64 App)
        {
            
            List<PermisosXMenuBE> PermisosXMenu = new List<PermisosXMenuBE>();
            try
            {
                Int64 iApp = App;
                var dbCommand = new SqlCommand("spFront_getMenusXAppRolAdmin")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
                dbCommand.Parameters.Add("@IdRol", SqlDbType.BigInt).Value = Rol;
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        PermisosXMenuBE Permiso = new PermisosXMenuBE();
                        Permiso.IDPERMISOSMENU = long.Parse(row["IDPERMISOSMENU"].ToString());
                        Permiso.IDROL = long.Parse(row["IDROL"].ToString());
                        Permiso.NOMBREMENU = row["NOMBREMENU"].ToString();
                        Permiso.IMAGEN = row["IMAGEN"].ToString();
                        Permiso.TIPOOBJETO = row["TIPOOBJETO"].ToString();
                        Permiso.URL = row["URL"].ToString();
                        Permiso.TOOLTIP = row["TOOLTIP"].ToString();
                        Permiso.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        Permiso.ORDENMENU = Convert.ToInt32(row["ORDEN"].ToString());
                        PermisosXMenu.Add(Permiso);
                    }
                }
                else throw new DbDataContextException(dbError);
              
                return PermisosXMenu;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisoXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, Int64 App)
        {
            
            List<PermisoXSubmenuBE> PermisosXSubmenu = new List<PermisoXSubmenuBE>();
            try
            {
                Int64 iApp = App;
                var dbCommand = new SqlCommand("spFront_getSubMenusXIdMenu")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = IdPermisoMenu;
               
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        PermisoXSubmenuBE Permiso = new PermisoXSubmenuBE();
                        Permiso.IDPERMISOSXSUBMENU = long.Parse(row["IDPERMISOSXSUBMENU"].ToString());
                        Permiso.IDPERMISOSMENU = long.Parse(row["IDPERMISOSMENU"].ToString());
                        Permiso.NOMBRESUBMENU = row["NOMBRESUBMENU"].ToString();
                        Permiso.IMAGEN = row["IMAGEN"].ToString();
                        Permiso.TIPOOBJETO = row["TIPOOBJETO"].ToString();
                        Permiso.URL = row["URL"].ToString();
                        Permiso.TOOLTIP = row["TOOLTIP"].ToString();
                        Permiso.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        Permiso.ORDENSUBMENU = Convert.ToInt32(row["ORDEN"].ToString());
                        PermisosXSubmenu.Add(Permiso);
                    }
                }
                else throw new DbDataContextException(dbError);
               
               
                return PermisosXSubmenu;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisoXSubmenuBE> getSubMenuXIdMenuAdmin(long IdPermisoMenu, Int64 App)
        {
            
            List<PermisoXSubmenuBE> PermisosXSubmenu = new List<PermisoXSubmenuBE>();
            try
            {

                Int64 iApp = App;
                var dbCommand = new SqlCommand("spFront_getSubMenusXIdMenuAdmin")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = IdPermisoMenu;
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        PermisoXSubmenuBE Permiso = new PermisoXSubmenuBE();
                        Permiso.IDPERMISOSXSUBMENU = long.Parse(row["IDPERMISOSXSUBMENU"].ToString());
                        Permiso.IDPERMISOSMENU = long.Parse(row["IDPERMISOSMENU"].ToString());
                        Permiso.NOMBRESUBMENU = row["NOMBRESUBMENU"].ToString();
                        Permiso.IMAGEN = row["IMAGEN"].ToString();
                        Permiso.TIPOOBJETO = row["TIPOOBJETO"].ToString();
                        Permiso.URL = row["URL"].ToString();
                        Permiso.TOOLTIP = row["TOOLTIP"].ToString();
                        Permiso.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        Permiso.ORDENSUBMENU = Convert.ToInt32(row["ORDEN"].ToString());
                        PermisosXSubmenu.Add(Permiso);
                    }
                }
                else throw new DbDataContextException(dbError);
                
                return PermisosXSubmenu;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<AplicacionBE> getAplicaciones(string idAplicacion, string txtBusqueda, Int64 App)
        {
            
            List<AplicacionBE> Aplicaciones = new List<AplicacionBE>();
            try
            {
                Int64 iApp = App;
                var dbCommand = new SqlCommand("spFront_getAplicaciones")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.VarChar).Value = idAplicacion;
                dbCommand.Parameters.Add("@TXTBUSQUEDA", SqlDbType.NVarChar).Value = txtBusqueda;
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        AplicacionBE Aplicacion = new AplicacionBE();
                        Aplicacion.IDAPLICACION = long.Parse(row["IDAPLICACION"].ToString());
                        Aplicacion.DESCRIPCION = row["DESCRIPCION"].ToString();
                        Aplicacion.PASSWORD = row["PASSWORD"].ToString();
                        Aplicacion.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        Aplicaciones.Add(Aplicacion);
                    }
                }
                else throw new DbDataContextException(dbError);
              
                return Aplicaciones;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool addAplicacion(AplicacionBE Aplicacion, Int64 App)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_insAplicacion")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Aplicacion.DESCRIPCION;
                dbCommand.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Aplicacion.PASSWORD;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Aplicacion.ACTIVO;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
               
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool updAplicacion(AplicacionBE Aplicacion, Int64 App)
        {
            
            try
            {
                bool bFlag = true;

                var dbCommand = new SqlCommand("spFront_updAplicacion")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.VarChar).Value = Aplicacion.IDAPLICACION;
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Aplicacion.DESCRIPCION;
                dbCommand.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Aplicacion.PASSWORD;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Aplicacion.ACTIVO;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);

             
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool updMenuxAppRol(Int64 idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_updMenuXAppRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = idMenu;
                dbCommand.Parameters.Add("@NOMBREMENU", SqlDbType.VarChar).Value = Menu;
                dbCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar).Value = Img;
                dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = TpoObj;
                dbCommand.Parameters.Add("@URL", SqlDbType.VarChar).Value = Url;
                dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
                dbCommand.Parameters.Add("@ORDEN", SqlDbType.BigInt).Value = Orden;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Activo;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App);
                throw new Exception(ex.Message);
            }
        }

        public bool updSubMenuxAppRol(Int64 idPermisoMenu, Int64 IdPermisoSubmenu, string SubMenu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_updSubMenuXAppRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = idPermisoMenu;
                dbCommand.Parameters.Add("@IDPERMISOSSUBMENU", SqlDbType.BigInt).Value = IdPermisoSubmenu;
                dbCommand.Parameters.Add("@NOMBRESUBMENU", SqlDbType.VarChar).Value = SubMenu;
                dbCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar).Value = Img;
                dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = TpoObj;
                dbCommand.Parameters.Add("@URL", SqlDbType.VarChar).Value = Url;
                dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
                dbCommand.Parameters.Add("@ORDEN", SqlDbType.BigInt).Value = Orden;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Activo;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool addRolxApp(string Rol, Int64 App)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_insRolXApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@ROL", SqlDbType.VarChar).Value = Rol;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
              
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool addMetodo(List<WCFMetodosBE> lstMetodos, Int64 IdApp)
        {  
            try
            {
                bool bFlag = true;
                foreach (var item in lstMetodos)
                {

                    var dbCommand = new SqlCommand("spFront_insMetodosxApp")
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    dbCommand.Parameters.Add("@IDMETODOS", SqlDbType.BigInt).Value = item.IDMETODOS;
                    dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = item.IDAPLICACION;
                    dbCommand.Parameters.Add("@IDSERVICIOS", SqlDbType.BigInt).Value = item.IDSERVICIOS;
                    dbCommand.Parameters.Add("@NOMBREMETODO", SqlDbType.VarChar).Value = item.NOMBREMETODO;
                    dbCommand.Parameters.Add("@RECURRENTE", SqlDbType.Bit).Value = item.RECURRENTE;
                    dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = item.ACTIVO;
                    if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                    {
                        if (rowsAffected > 0)
                            bFlag = true;
                        else
                            bFlag = false;
                    }
                }
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
                throw new Exception(ex.Message);
            }
            
        }

        public bool addServicio(string Servicio)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_insServicioWCF")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Servicio;
            
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
               
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }

        public bool addSubMenuxAppRol(Int64 IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, Int64 Orden)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_insSubMenuXAppRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = IdSubMenu;
                dbCommand.Parameters.Add("@NOMBRESUBMENU", SqlDbType.VarChar).Value = SubMenu;
                dbCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar).Value = Img;
                dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = Obj;
                dbCommand.Parameters.Add("@URL", SqlDbType.VarChar).Value = Url;
                dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
                dbCommand.Parameters.Add("@ORDEN", SqlDbType.BigInt).Value = Orden;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
               
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }

        public bool addMenuxAppRol(Int64 Rol, Int64 App, string Menu, string Img, string Obj, string Url, string Tool, Int64 Orden)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_insMenuXAppRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = Rol;
                dbCommand.Parameters.Add("@NOMBREMENU", SqlDbType.VarChar).Value = Menu;
                dbCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar).Value = Img;
                dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = Obj;
                dbCommand.Parameters.Add("@URL", SqlDbType.VarChar).Value = Url;
                dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
                dbCommand.Parameters.Add("@ORDEN", SqlDbType.BigInt).Value = Orden;

                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
               
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }

        public bool addPermisosxObjeto(Int64 Rol, string Pagina, string Obj, string TipoObjeto, string Tool)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_insPermisosxObjeto")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = Rol;
                dbCommand.Parameters.Add("@PAGINA", SqlDbType.VarChar).Value = Pagina;
                dbCommand.Parameters.Add("@NOMBREOBJETO", SqlDbType.VarChar).Value = Obj;
                dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = TipoObjeto;
                dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
                

                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
              
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }

        public bool addPermisosxElementoObjeto(Int64 PermisoObj, string Elemento, string Tool)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_insPermisosxElementoObjeto")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDPERMISOSOBJ", SqlDbType.BigInt).Value = PermisoObj;
                dbCommand.Parameters.Add("@ELEMENTO", SqlDbType.VarChar).Value = Elemento;
                dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;


                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }

        public bool delMenu(Int64 idMenu, Int64 App)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_delMenusXAppRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdMenu", SqlDbType.BigInt).Value = idMenu;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool delSubMenu(Int64 idSubMenu, Int64 App)
        {
            
            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spFront_delSubMenusXAppRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdSubMenu", SqlDbType.BigInt).Value = idSubMenu;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool checkApp(string App)
        {
            
            bool bFlag = false;
            try
            {
                var dbCommand = new SqlCommand("spFront_checkXApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@APLICACION", SqlDbType.VarChar).Value = App;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        bFlag = true;
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);

            }

            return bFlag;
        }

        public bool checkRol(string Rol, Int64 App)
        {
            
            bool bFlag = false;
            try
            {
                var dbCommand = new SqlCommand("spFront_checkRolxApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@ROL", SqlDbType.VarChar).Value = Rol;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        bFlag = true;
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
              
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);

            }

            return bFlag;
        }

        public bool checkMetodo(string Metodo, Int64 IdApp, Int64 Servicio)
        {
            
            bool bFlag = false;
            try
            {
                var dbCommand = new SqlCommand("spFront_checkMetodo")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@METODO", SqlDbType.VarChar).Value = Metodo;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = IdApp;
                dbCommand.Parameters.Add("@IDSERVICIOS", SqlDbType.BigInt).Value = Servicio;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        bFlag = true;
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
                
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
                throw new Exception(ex.Message);

            }

            return bFlag;
        }

        public bool checkServicio(string Servicio, Int64 IdApp)
        {
            
            bool bFlag = false;
            try
            {
                var dbCommand = new SqlCommand("spFront_checkServicio")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@SERVICIO", SqlDbType.VarChar).Value = Servicio;
               

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        bFlag = true;
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
              

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
                throw new Exception(ex.Message);

            }

            return bFlag;
        }

        public bool checkMenuxAppRol(string Menu, Int64 Rol, Int64 IdApp)
        {
            
            bool bFlag = false;
            try
            {
                var dbCommand = new SqlCommand("spFront_checkMenuxAppRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@MENU", SqlDbType.VarChar).Value = Menu;
                dbCommand.Parameters.Add("@IDROL", SqlDbType.VarChar).Value = Rol;
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        bFlag = true;
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
                throw new Exception(ex.Message);

            }

            return bFlag;
        }

        public bool checkSubMenuxAppRol(string SubMenu, Int64 PermisosMenu)
        {
            
            bool bFlag = false;
            try
            {
                var dbCommand = new SqlCommand("spFront_checkSubMenuxAppRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@SUBMENU", SqlDbType.VarChar).Value = SubMenu;
                dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = PermisosMenu;
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        bFlag = true;
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);

            }

            return bFlag;
        }

        public List<EstacionesXAppBE> getEstacionesXAppComp(Int64 IdApp, long App)
        {
            try
            {
                
                List<EstacionesXAppBE> ListaEstaciones = new List<EstacionesXAppBE>();


                var dbCommand = new SqlCommand("sp_getEstacionesXApps")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = IdApp;
                
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        EstacionesXAppBE EstacionesItem = new EstacionesXAppBE();
                        EstacionesItem.IDESTACIONXAPP = Convert.ToInt64(row["IDESTACIONXAPP"].ToString());
                        EstacionesItem.IDAPLICACION = Convert.ToInt64(row["IDAPLICACION"].ToString());;
                        EstacionesItem.IDESTACION = Convert.ToInt32(row["IDESTACION"].ToString());
                        // EstacionesItem.IDESTACIONPARTICULAR = s.IDESTACIONPARTICULAR ?? 0;
                        EstacionesItem.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        ListaEstaciones.Add(EstacionesItem);
                    }
                    return ListaEstaciones;
                }
                else throw new DbDataContextException(dbError);
               
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public List<EstacionesXAppBE> getEstacionesXID(long IdEstacion, long App)
        {
            try
            {
                
                List<EstacionesXAppBE> ListaEstaciones = new List<EstacionesXAppBE>();

                var dbCommand = new SqlCommand("sp_getEstacionesXID")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDESTACIONXAPP", SqlDbType.BigInt).Value = IdEstacion;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        EstacionesXAppBE EstacionesItem = new EstacionesXAppBE();
                        EstacionesItem.IDESTACIONXAPP = Convert.ToInt64(row["IDESTACIONXAPP"].ToString());
                        EstacionesItem.IDAPLICACION = Convert.ToInt64(row["IDAPLICACION"].ToString()); ;
                        EstacionesItem.IDESTACION = Convert.ToInt32(row["IDESTACION"].ToString());
                        EstacionesItem.IDESTACIONPARTICULAR = Convert.ToInt32(row["IDESTACIONPARTICULAR"].ToString());
                        EstacionesItem.DESCRIPCION = row["DESCRIPCION"].ToString();
                        EstacionesItem.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
                        ListaEstaciones.Add(EstacionesItem);
                    }
                    return ListaEstaciones;
                }
                else throw new DbDataContextException(dbError);
               
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public AplicacionBE getAppInfoDat(string xAppId)
        {
            
            try
            {
                AplicacionBE sRes = new AplicacionBE();
                var dbCommand = new SqlCommand("spGetAppInfo")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@xAppId", SqlDbType.NVarChar).Value = xAppId;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        sRes.IDAPLICACION = Convert.ToInt64(row["IDAPLICACION"].ToString());
                        sRes.DESCRIPCION = row["DESCRIPCION"].ToString();
                        sRes.PASSWORD = row["PASSWORD"].ToString();
                        sRes.jwtKey = row["JWTKEY"].ToString();
                        sRes.jwtExpirationTime = Convert.ToInt32(row["JWTEXPIRATIONTIME"].ToString());
                        sRes.URLINICIO = row["URLINICIO"].ToString();
                    }
                    return sRes;
                }
                else throw new DbDataContextException(dbError);
               }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }

        public List<AppsUsuarioBE> getAplicacionesUsuario(int idUsuario)
        {
            
            List<AppsUsuarioBE> AplicacionesUsuario = new List<AppsUsuarioBE>();
            try
            {
                var dbCommand = new SqlCommand("sp_getAppsXUsuarioMenu")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = idUsuario;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        AppsUsuarioBE Aplicacion = new AppsUsuarioBE();
                        Aplicacion.IDAPLICACION = Convert.ToInt64(row["IDAPLICACION"].ToString());
                        Aplicacion.IDROL = Convert.ToInt32(row["IDROL"].ToString());
                        Aplicacion.DESCRIPCION = row["DESCRIPCION"].ToString();
                        AplicacionesUsuario.Add(Aplicacion);
                    }
                    return AplicacionesUsuario;
                }
                else throw new DbDataContextException(dbError);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }

        public List<RolesUserApp> getRolesUserApp(string idUsuario, int iBusqueda, Int64 idApp)
        {
            
            List<RolesUserApp> AplicacionesUsuario = new List<RolesUserApp>();
            try
            {

                var dbCommand = new SqlCommand("sp_getRolesXUserApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@TIPOBUSQUEDA", SqlDbType.Int).Value = iBusqueda;
                dbCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = idUsuario;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = idApp;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        RolesUserApp Aplicacion = new RolesUserApp();
                        Aplicacion.IDROL = Convert.ToInt32(row["IDROL"].ToString());
                        Aplicacion.DESCRIPCION = row["DESCROL"].ToString();
                    }
                    return AplicacionesUsuario;
                }
                else throw new DbDataContextException(dbError);         
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                _securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }

       


    }
}
