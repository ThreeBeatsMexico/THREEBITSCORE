using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Common;
using ThreeBits.Interfaces.Security.Security;
using static ThreeBits.Data.Common.SqlDataContext;

namespace ThreeBits.Services.Security
{
	public class SecurityServiceDA : SqlDataContext, ISecurityServiceDA
	{
		private readonly ILogger _logger;

		private readonly IConfiguration _configuration;

		private readonly ICommonServiceDA _securityCommon;

		public SecurityServiceDA(ILogger<SecurityServiceDA> logger, IConfiguration configuration, ICommonServiceDA securityCommonDA)
		{
			_logger = logger;
			_configuration = configuration;
			_connectionString = _configuration["ConnectionStrings:DefaultConnection"];
			_securityCommon = securityCommonDA;
		}

		public AplicacionBE checkPermisoXAplicacion(long App, string sPasswordApp)
		{
			AplicacionBE PermisosXApp = new AplicacionBE();
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_getPermisoXApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					{
						IEnumerator enumerator = DataTable.Rows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								DataRow row = (DataRow)enumerator.Current;
								PermisosXApp.IDAPLICACION = long.Parse(row["IDAPLICACION"].ToString());
								PermisosXApp.DESCRIPCION = row["DESCRIPCION"].ToString();
								PermisosXApp.PASSWORD = row["PASSWORD"].ToString();
								PermisosXApp.ACTIVO = row["ACTIVO"] != null && bool.Parse(row["ACTIVO"].ToString());
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					return PermisosXApp;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<WCFMetodosBE> checkMetodoXApp(long App, string sServiceName, string sMethodName)
		{
			List<WCFMetodosBE> MetodosXApp = new List<WCFMetodosBE>();
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_getMetodoXApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
				dbCommand.Parameters.Add("@SERVICENAME", SqlDbType.VarChar).Value = sServiceName;
				dbCommand.Parameters.Add("@METHODNAME", SqlDbType.VarChar).Value = sMethodName;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
					return MetodosXApp;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<PermisosXObjetosBE> getObjetosXAppRolPage(long Rol, string Pagina, long App)
		{
			List<PermisosXObjetosBE> PermisoXObjetos = new List<PermisosXObjetosBE>();
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_getObjetosXAppRolPage")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
				dbCommand.Parameters.Add("@IdRol", SqlDbType.BigInt).Value = Rol;
				dbCommand.Parameters.Add("@Pagina", SqlDbType.VarChar).Value = Pagina;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
					return PermisoXObjetos;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<PermisoXElementosObjBE> getElementsObjectsXIdObj(long IdPermisosXObj, long App)
		{
			List<PermisoXElementosObjBE> PermisoXElementosObj = new List<PermisoXElementosObjBE>();
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_getElementsObjectsXIdObj")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDELEMENTOSXOBJ", SqlDbType.BigInt).Value = IdPermisosXObj;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
					return PermisoXElementosObj;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<PermisosXMenuBE> getMenuXAppRol(long Rol, long App)
		{
			List<PermisosXMenuBE> PermisosXMenu = new List<PermisosXMenuBE>();
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_getMenusXAppRol")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
				dbCommand.Parameters.Add("@IdRol", SqlDbType.BigInt).Value = Rol;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
					return PermisosXMenu;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<PermisosXMenuBE> getMenuXAppRolAdmin(long Rol, long App)
		{
			List<PermisosXMenuBE> PermisosXMenu = new List<PermisosXMenuBE>();
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_getMenusXAppRolAdmin")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IdApp", SqlDbType.BigInt).Value = App;
				dbCommand.Parameters.Add("@IdRol", SqlDbType.BigInt).Value = Rol;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
					return PermisosXMenu;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<PermisoXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, long App)
		{
			List<PermisoXSubmenuBE> PermisosXSubmenu = new List<PermisoXSubmenuBE>();
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_getSubMenusXIdMenu")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = IdPermisoMenu;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
					return PermisosXSubmenu;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<PermisoXSubmenuBE> getSubMenuXIdMenuAdmin(long IdPermisoMenu, long App)
		{
			List<PermisoXSubmenuBE> PermisosXSubmenu = new List<PermisoXSubmenuBE>();
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_getSubMenusXIdMenuAdmin")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = IdPermisoMenu;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
					return PermisosXSubmenu;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<AplicacionBE> getAplicaciones(string idAplicacion, string txtBusqueda, long App)
		{
			List<AplicacionBE> Aplicaciones = new List<AplicacionBE>();
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_getAplicaciones")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.VarChar).Value = idAplicacion;
				dbCommand.Parameters.Add("@TXTBUSQUEDA", SqlDbType.NVarChar).Value = txtBusqueda;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
					return Aplicaciones;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool addAplicacion(AplicacionBE Aplicacion, long App)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_insAplicacion")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Aplicacion.DESCRIPCION;
				dbCommand.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Aplicacion.PASSWORD;
				dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Aplicacion.ACTIVO;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool updAplicacion(AplicacionBE Aplicacion, long App)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_updAplicacion")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.VarChar).Value = Aplicacion.IDAPLICACION;
				dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Aplicacion.DESCRIPCION;
				dbCommand.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Aplicacion.PASSWORD;
				dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Aplicacion.ACTIVO;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool updMenuxAppRol(long idMenu, string Menu, string Img, string TpoObj, string Url, string Tool, long Orden, bool Activo, string App)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_updMenuXAppRol")
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
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App);
				throw new Exception(ex.Message);
			}
		}

		public bool updSubMenuxAppRol(long idPermisoMenu, long IdPermisoSubmenu, string SubMenu, string Img, string TpoObj, string Url, string Tool, long Orden, bool Activo, string App)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_updSubMenuXAppRol")
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
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool addRolxApp(string Rol, long App)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_insRolXApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@ROL", SqlDbType.VarChar).Value = Rol;
				dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool addMetodo(List<WCFMetodosBE> lstMetodos, long IdApp)
		{
			try
			{
				bool bFlag = true;
				foreach (WCFMetodosBE item in lstMetodos)
				{
					SqlCommand dbCommand = new SqlCommand("spFront_insMetodosxApp")
					{
						CommandType = CommandType.StoredProcedure
					};
					dbCommand.Parameters.Add("@IDMETODOS", SqlDbType.BigInt).Value = item.IDMETODOS;
					dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = item.IDAPLICACION;
					dbCommand.Parameters.Add("@IDSERVICIOS", SqlDbType.BigInt).Value = item.IDSERVICIOS;
					dbCommand.Parameters.Add("@NOMBREMETODO", SqlDbType.VarChar).Value = item.NOMBREMETODO;
					dbCommand.Parameters.Add("@RECURRENTE", SqlDbType.Bit).Value = item.RECURRENTE;
					dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = item.ACTIVO;
					if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var _))
					{
						bFlag = ((rowsAffected > 0) ? true : false);
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
				SqlCommand dbCommand = new SqlCommand("spFront_insServicioWCF")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Servicio;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
				throw new Exception(ex.Message);
			}
		}

		public bool addSubMenuxAppRol(long IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, long Orden)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_insSubMenuXAppRol")
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
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
				throw new Exception(ex.Message);
			}
		}

		public bool addMenuxAppRol(long Rol, long App, string Menu, string Img, string Obj, string Url, string Tool, long Orden)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_insMenuXAppRol")
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
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
				throw new Exception(ex.Message);
			}
		}

		public bool addPermisosxObjeto(long Rol, string Pagina, string Obj, string TipoObjeto, string Tool)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_insPermisosxObjeto")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = Rol;
				dbCommand.Parameters.Add("@PAGINA", SqlDbType.VarChar).Value = Pagina;
				dbCommand.Parameters.Add("@NOMBREOBJETO", SqlDbType.VarChar).Value = Obj;
				dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = TipoObjeto;
				dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
				throw new Exception(ex.Message);
			}
		}

		public bool addPermisosxElementoObjeto(long PermisoObj, string Elemento, string Tool)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_insPermisosxElementoObjeto")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDPERMISOSOBJ", SqlDbType.BigInt).Value = PermisoObj;
				dbCommand.Parameters.Add("@ELEMENTO", SqlDbType.VarChar).Value = Elemento;
				dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
				throw new Exception(ex.Message);
			}
		}

		public bool delMenu(long idMenu, long App)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_delMenusXAppRol")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IdMenu", SqlDbType.BigInt).Value = idMenu;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool delSubMenu(long idSubMenu, long App)
		{
			try
			{
				bool bFlag = true;
				SqlCommand dbCommand = new SqlCommand("spFront_delSubMenusXAppRol")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IdSubMenu", SqlDbType.BigInt).Value = idSubMenu;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
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
				SqlCommand dbCommand = new SqlCommand("spFront_checkXApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@APLICACION", SqlDbType.VarChar).Value = App;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					IEnumerator enumerator = DataTable.Rows.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							_ = (DataRow)enumerator.Current;
							return true;
						}
						return bFlag;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool checkRol(string Rol, long App)
		{
			bool bFlag = false;
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_checkRolxApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@ROL", SqlDbType.VarChar).Value = Rol;
				dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					IEnumerator enumerator = DataTable.Rows.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							_ = (DataRow)enumerator.Current;
							return true;
						}
						return bFlag;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool checkMetodo(string Metodo, long IdApp, long Servicio)
		{
			bool bFlag = false;
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_checkMetodo")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@METODO", SqlDbType.VarChar).Value = Metodo;
				dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = IdApp;
				dbCommand.Parameters.Add("@IDSERVICIOS", SqlDbType.BigInt).Value = Servicio;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					IEnumerator enumerator = DataTable.Rows.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							_ = (DataRow)enumerator.Current;
							return true;
						}
						return bFlag;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool checkServicio(string Servicio, long IdApp)
		{
			bool bFlag = false;
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_checkServicio")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@SERVICIO", SqlDbType.VarChar).Value = Servicio;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					IEnumerator enumerator = DataTable.Rows.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							_ = (DataRow)enumerator.Current;
							return true;
						}
						return bFlag;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool checkMenuxAppRol(string Menu, long Rol, long IdApp)
		{
			bool bFlag = false;
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_checkMenuxAppRol")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@MENU", SqlDbType.VarChar).Value = Menu;
				dbCommand.Parameters.Add("@IDROL", SqlDbType.VarChar).Value = Rol;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					IEnumerator enumerator = DataTable.Rows.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							_ = (DataRow)enumerator.Current;
							return true;
						}
						return bFlag;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool checkSubMenuxAppRol(string SubMenu, long PermisosMenu)
		{
			bool bFlag = false;
			try
			{
				SqlCommand dbCommand = new SqlCommand("spFront_checkSubMenuxAppRol")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@SUBMENU", SqlDbType.VarChar).Value = SubMenu;
				dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = PermisosMenu;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					IEnumerator enumerator = DataTable.Rows.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							_ = (DataRow)enumerator.Current;
							return true;
						}
						return bFlag;
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
				throw new Exception(ex.Message);
			}
		}

		public List<EstacionesXAppBE> getEstacionesXAppComp(long IdApp, long App)
		{
			try
			{
				List<EstacionesXAppBE> ListaEstaciones = new List<EstacionesXAppBE>();
				SqlCommand dbCommand = new SqlCommand("sp_getEstacionesXApps")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = IdApp;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						EstacionesXAppBE EstacionesItem = new EstacionesXAppBE();
						EstacionesItem.IDESTACIONXAPP = Convert.ToInt64(row["IDESTACIONXAPP"].ToString());
						EstacionesItem.IDAPLICACION = Convert.ToInt64(row["IDAPLICACION"].ToString());
						EstacionesItem.IDESTACION = Convert.ToInt32(row["IDESTACION"].ToString());
						EstacionesItem.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
						ListaEstaciones.Add(EstacionesItem);
					}
					return ListaEstaciones;
				}
				throw new DbDataContextException(dbError);
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
				SqlCommand dbCommand = new SqlCommand("sp_getEstacionesXID")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDESTACIONXAPP", SqlDbType.BigInt).Value = IdEstacion;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						EstacionesXAppBE EstacionesItem = new EstacionesXAppBE();
						EstacionesItem.IDESTACIONXAPP = Convert.ToInt64(row["IDESTACIONXAPP"].ToString());
						EstacionesItem.IDAPLICACION = Convert.ToInt64(row["IDAPLICACION"].ToString());
						EstacionesItem.IDESTACION = Convert.ToInt32(row["IDESTACION"].ToString());
						EstacionesItem.IDESTACIONPARTICULAR = Convert.ToInt32(row["IDESTACIONPARTICULAR"].ToString());
						EstacionesItem.DESCRIPCION = row["DESCRIPCION"].ToString();
						EstacionesItem.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
						ListaEstaciones.Add(EstacionesItem);
					}
					return ListaEstaciones;
				}
				throw new DbDataContextException(dbError);
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
				SqlCommand dbCommand = new SqlCommand("spGetAppInfo")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@xAppId", SqlDbType.NVarChar).Value = xAppId;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
				throw new DbDataContextException(dbError);
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
				SqlCommand dbCommand = new SqlCommand("sp_getAppsXUsuarioMenu")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = idUsuario;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
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
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				_securityCommon.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
				throw new Exception(ex.Message);
			}
		}

		public List<RolesUserApp> getRolesUserApp(string idUsuario, int iBusqueda, long idApp)
		{
			List<RolesUserApp> AplicacionesUsuario = new List<RolesUserApp>();
			try
			{
				SqlCommand dbCommand = new SqlCommand("sp_getRolesXUserApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@TIPOBUSQUEDA", SqlDbType.Int).Value = iBusqueda;
				dbCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = idUsuario;
				dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = idApp;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						new RolesUserApp
						{
							IDROL = Convert.ToInt32(row["IDROL"].ToString()),
							DESCRIPCION = row["DESCROL"].ToString()
						};
					}
					return AplicacionesUsuario;
				}
				throw new DbDataContextException(dbError);
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
