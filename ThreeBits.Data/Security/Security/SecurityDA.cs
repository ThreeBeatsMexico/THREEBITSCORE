using Microsoft.Extensions.Configuration;using Microsoft.Extensions.Logging;using System;using System.Collections.Generic;using System.Data.SqlClient;using System.Data;using System.Diagnostics;using System.Linq;using System.Reflection;using System.Text;using System.Threading.Tasks;using ThreeBits.Data.Common;using ThreeBits.Entities.Security;using Microsoft.Extensions.Hosting;using Microsoft.Extensions.DependencyInjection;using ThreeBits.Interfaces.Security.Security;using static ThreeBits.Data.Common.SqlDataContext;namespace ThreeBits.Data.Security{    public class SecurityDA : SqlDataContext, ISecurityServiceDA    {        private readonly ILogger _logger;        private readonly IConfiguration _configuration;        public SecurityDA(ILogger<SecurityDA> logger,            IConfiguration configuration)        {            _logger = logger;            _configuration = configuration;            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];        }        public DataTable checkPermisoXAplicacion(Int64 App, string sPasswordApp)        {

            var dbCommand = new SqlCommand("sp_getPermisoXApp")            {                CommandType = CommandType.StoredProcedure            };            dbCommand.Parameters.Add("@IdApp", SqlDbType.Int).Value = App;            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError)) return DataTable;            else throw new DbDataContextException(dbError);
        }        public DataTable checkMetodoXApp(Int64 App, string sServiceName, string sMethodName)        {            var dbCommand = new SqlCommand("sp_getMetodoXApp")            {                CommandType = CommandType.StoredProcedure            };            dbCommand.Parameters.Add("@IdApp", SqlDbType.Int).Value = App;            dbCommand.Parameters.Add("@SERVICENAME", SqlDbType.VarChar).Value = sServiceName;            dbCommand.Parameters.Add("@METHODNAME", SqlDbType.VarChar).Value = sMethodName;            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError)) return DataTable;            else throw new DbDataContextException(dbError);        }        public DataTable getObjetosXAppRolPage(long Rol, string Pagina, Int64 App)        {            var dbCommand = new SqlCommand("sp_getObjetosXAppRolPage")            {                CommandType = CommandType.StoredProcedure            };            dbCommand.Parameters.Add("@IdApp", SqlDbType.VarChar).Value = App;            dbCommand.Parameters.Add("@SERVICENAME", SqlDbType.VarChar).Value = Rol;            dbCommand.Parameters.Add("@METHODNAME", SqlDbType.VarChar).Value = Pagina;            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))            {                return DataTable;            }            else throw new DbDataContextException(dbError);        }        public DataTable getElementsObjectsXIdObj(long IdPermisosXObj, Int64 App)        {

            var dbCommand = new SqlCommand("sp_getElementsObjectsXIdObj")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IDELEMENTOSXOBJ", SqlDbType.BigInt).Value = IdPermisosXObj;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);


        }        public DataTable getMenuXAppRol(long Rol, Int64 App)        {
            var dbCommand = new SqlCommand("sp_getMenusXAppRol")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
            dbCommand.Parameters.Add("@IdRol", SqlDbType.BigInt).Value = Rol;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);        }


        public DataTable getMenuXAppRolAdmin(long Rol, Int64 App)        {
            var dbCommand = new SqlCommand("sp_getMenusXAppRolAdmin")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
            dbCommand.Parameters.Add("@IdRol", SqlDbType.BigInt).Value = Rol;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);


        }        public DataTable getSubMenuXIdMenu(long IdPermisoMenu, Int64 App)        {

            var dbCommand = new SqlCommand("sp_getSubMenusXIdMenu")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = App;


            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);



        }




        public DataTable getSubMenuXIdMenuAdmin(long IdPermisoMenu, Int64 App)        {            var dbCommand = new SqlCommand("sp_getSubMenusXIdMenuAdmin")            {                CommandType = CommandType.StoredProcedure            };            dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = App;            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))            {                return DataTable;            }            else throw new DbDataContextException(dbError);        }




        public DataTable getAplicaciones(string idAplicacion, string txtBusqueda, Int64 App)        {
            var dbCommand = new SqlCommand("sp_getAplicaciones")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.VarChar).Value = App;
            dbCommand.Parameters.Add("@TXTBUSQUEDA", SqlDbType.BigInt).Value = txtBusqueda;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);



        }        public DataTable addAplicacion(AplicacionBE Aplicacion, Int64 App)        {
            var dbCommand = new SqlCommand("sp_insAplicacion")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Aplicacion.DESCRIPCION;
            dbCommand.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Aplicacion.PASSWORD;
            dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Aplicacion.ACTIVO;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);



        }

        public DataTable updAplicacion(AplicacionBE Aplicacion, Int64 App)        {
            var dbCommand = new SqlCommand("sp_updAplicacion")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = Aplicacion.IDAPLICACION;
            dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Aplicacion.DESCRIPCION;
            dbCommand.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Aplicacion.PASSWORD;
            dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Aplicacion.ACTIVO;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);
            
        }


        public DataTable updMenuxAppRol(Int64 idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App)        {

            var dbCommand = new SqlCommand("sp_updMenuXAppRol")
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

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);





        }        public DataTable updSubMenuxAppRol(Int64 idPermisoMenu, Int64 IdPermisoSubmenu, string SumMenu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App)        {

            var dbCommand = new SqlCommand("sp_updSubMenuXAppRol")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = idPermisoMenu;
            dbCommand.Parameters.Add("@IDPERMISOSSUBMENU", SqlDbType.BigInt).Value = IdPermisoSubmenu;
            dbCommand.Parameters.Add("@NOMBRESUBMENU", SqlDbType.VarChar).Value = SumMenu;
            dbCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar).Value = Img;
            dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = TpoObj;
            dbCommand.Parameters.Add("@URL", SqlDbType.VarChar).Value = Url;
            dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
            dbCommand.Parameters.Add("@ORDEN", SqlDbType.BigInt).Value = Orden;
            dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Activo;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);        }        public DataTable addRolxApp(string Rol, Int64 App)        {
            var dbCommand = new SqlCommand("sp_insRolXApp")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@ROL", SqlDbType.VarChar).Value = Rol;
            dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);


        }        public DataTable addMetodo(List<WCFMetodosBE> lstMetodos, Int64 IdApp)        {
            DataTable oRes = new DataTable();
            foreach (var item in lstMetodos)
            {
                var dbCommand = new SqlCommand("sp_insMetodosxApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDMETODOS", SqlDbType.BigInt).Value = item.IDMETODOS;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = item.IDAPLICACION;
                dbCommand.Parameters.Add("@IDSERVICIOS", SqlDbType.BigInt).Value = item.IDSERVICIOS;
                dbCommand.Parameters.Add("@NOMBREMETODO", SqlDbType.VarChar).Value = item.NOMBREMETODO;
                dbCommand.Parameters.Add("@RECURRENTE", SqlDbType.Bit).Value = item.RECURRENTE;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = item.ACTIVO;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    return DataTable;
                }
                else throw new DbDataContextException(dbError);
            }
            return oRes;

        }        public DataTable addServicio(string Servicio)        {
            var dbCommand = new SqlCommand("sp_insServicioWCF")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Servicio;


            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);
        }        public DataTable addSubMenuxAppRol(Int64 IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, Int64 Orden)        {

            var dbCommand = new SqlCommand("sp_insSubMenuXAppRol")
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

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);        }        public DataTable addMenuxAppRol(Int64 Rol, Int64 App, string Menu, string Img, string Obj, string Url, string Tool, Int64 Orden)        {

            var dbCommand = new SqlCommand("sp_insMenuXAppRol")
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
            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);
        }        public DataTable addPermisosxObjeto(Int64 Rol, string Pagina, string Obj, string TipoObjeto, string Tool)        {

            var dbCommand = new SqlCommand("sp_insPermisosxObjeto")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = Rol;
            dbCommand.Parameters.Add("@PAGINA", SqlDbType.VarChar).Value = Pagina;
            dbCommand.Parameters.Add("@NOMBREOBJETO", SqlDbType.VarChar).Value = Obj;
            dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = TipoObjeto;
            dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);


        }        public DataTable addPermisosxElementoObjeto(Int64 PermisoObj, string Elemento, string Tool)        {
            var dbCommand = new SqlCommand("sp_insPermisosxElementoObjeto")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IDPERMISOSOBJ", SqlDbType.BigInt).Value = PermisoObj;
            dbCommand.Parameters.Add("@ELEMENTO", SqlDbType.VarChar).Value = Elemento;
            dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);

        }


        public DataTable delMenu(Int64 idMenu, Int64 App)        {

            var dbCommand = new SqlCommand("sp_delMenusXAppRol")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IdMenu", SqlDbType.BigInt).Value = idMenu;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);
        }        public DataTable delSubMenu(Int64 idSubMenu, Int64 App)        {
            var dbCommand = new SqlCommand("sp_delSubMenusXAppRol")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IdSubMenu", SqlDbType.BigInt).Value = idSubMenu;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);
        }        public DataTable checkApp(string App)        {
            var dbCommand = new SqlCommand("sp_checkXApp")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@APLICACION", SqlDbType.VarChar).Value = App;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);

        }        public DataTable checkRol(string Rol, Int64 App)        {

            var dbCommand = new SqlCommand("sp_checkRolxApp")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@ROL", SqlDbType.VarChar).Value = Rol;
            dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);

        }        public DataTable checkMetodo(string Metodo, Int64 IdApp, Int64 Servicio)        {
            var dbCommand = new SqlCommand("sp_checkMetodo")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@METODO", SqlDbType.VarChar).Value = Metodo;
            dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = IdApp;
            dbCommand.Parameters.Add("@IDSERVICIOS", SqlDbType.BigInt).Value = Servicio;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);
        }        public DataTable checkServicio(string Servicio, Int64 IdApp)        {


            var dbCommand = new SqlCommand("sp_checkServicio")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@SERVICIO", SqlDbType.VarChar).Value = Servicio;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);




        }        public DataTable checkMenuxAppRol(string Menu, Int64 Rol, Int64 IdApp)        {

            var dbCommand = new SqlCommand("sp_checkMenuxAppRol")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@MENU", SqlDbType.VarChar).Value = Menu;
            dbCommand.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = Rol;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);

        }        public DataTable checkSubMenuxAppRol(string SubMenu, Int64 PermisosMenu)        {

            var dbCommand = new SqlCommand("sp_checkSubMenuxAppRol")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@SUBMENU", SqlDbType.VarChar).Value = SubMenu;
            dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = PermisosMenu;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);
        }        public DataTable getAppInfoDat(string xAppId)        {            var dbCommand = new SqlCommand("spGetAppInfo")            {                CommandType = CommandType.StoredProcedure            };            dbCommand.Parameters.Add("@xAppId", SqlDbType.VarChar).Value = xAppId;            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError)) return DataTable;            else throw new DbDataContextException(dbError);        }

    }
}