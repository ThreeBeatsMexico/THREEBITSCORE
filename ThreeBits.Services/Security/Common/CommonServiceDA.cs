using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Common;
using ThreeBits.Interfaces.Common;

namespace ThreeBits.Services.Security.Common
{
	public class CommonServiceDA : MySqlDataContext, ICommonServiceDA
	{
		private readonly ILogger _logger;

		private readonly IConfiguration _configuration;

		public CommonServiceDA(ILogger<CommonServiceDA> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
            _MySqlconnectionString = _configuration["ConnectionStrings:MySqlConnection"];
        }

		public RespuestaComunBE GetCatGenerales(CatGeneralesBE item)
		{
			RespuestaComunBE RespuestaComun = new RespuestaComunBE();
			RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
			RespuestaComun.itemError = new ErrorBE();
			RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);
			try
			{
                MySqlCommand dbCommand = new MySqlCommand("spFrontGetCatGenerales")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IDCATGENERALES", MySqlDbType.Int32).Value = item.psIDCATGENERALES;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						CatGeneralesBE itemLector = new CatGeneralesBE();
						itemLector.psIDCATGENERALES = row["IDCATGENERALES"].ToString();
						itemLector.psNOMBRECATALOGO = row["NOMBRECATALOGO"].ToString();
						itemLector.psIDCATALOGO = row["IDCATALOGO"].ToString();
						itemLector.psDESCRIPCION = row["DESCRIPCION"].ToString();
						itemLector.psFILTRO = row["FILTRO"].ToString();
						itemLector.psACTIVO = row["ACTIVO"].ToString();
						RespuestaComun.lstCatGenerales.Add(itemLector);
					}
					return RespuestaComun;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
				throw new Exception(ex.Message);
			}
		}

		public RespuestaComunBE AddCatGenerales(CatGeneralesBE item)
		{
			RespuestaComunBE RespuestaComun = new RespuestaComunBE();
			_ = string.Empty;
			RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
			RespuestaComun.itemError = new ErrorBE();
			RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spAddCatGenerales")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@NOMBRECATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@IDCATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@DESCRIPCION", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@FILTRO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@ACTIVO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@NOMBRECATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						CatGeneralesBE itemLector = new CatGeneralesBE();
						itemLector.psIDCATGENERALES = row["IDCATGENERALES"].ToString();
						itemLector.psNOMBRECATALOGO = row["NOMBRECATALOGO"].ToString();
						itemLector.psIDCATALOGO = row["IDCATALOGO"].ToString();
						itemLector.psDESCRIPCION = row["DESCRIPCION"].ToString();
						itemLector.psFILTRO = row["FILTRO"].ToString();
						itemLector.psACTIVO = row["ACTIVO"].ToString();
						RespuestaComun.lstCatGenerales.Add(itemLector);
					}
					return RespuestaComun;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
				throw new Exception(ex.Message);
			}
		}

		public RespuestaComunBE SetCatGenerales(CatGeneralesBE item)
		{
			RespuestaComunBE RespuestaComun = new RespuestaComunBE();
			_ = string.Empty;
			RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
			RespuestaComun.itemError = new ErrorBE();
			RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spSetCatGenerales")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@NOMBRECATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@IDCATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@DESCRIPCION", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@FILTRO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@ACTIVO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@NOMBRECATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
					}
					return RespuestaComun;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
				throw new Exception(ex.Message);
			}
		}

		public RespuestaComunBE GetCatEspecifico(CatGeneralesBE item)
		{
			RespuestaComunBE RespuestaComun = new RespuestaComunBE();
			_ = string.Empty;
			RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
			RespuestaComun.itemError = new ErrorBE();
			RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spGetCatEspecifico")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDCATGENERALES", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@NOMBRECATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@IDCATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@DESCRIPCION", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@FILTRO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@ACTIVO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@VALORFILTRO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						CatalogosBE itemLector = new CatalogosBE();
						itemLector.ID = row["ID"].ToString();
						itemLector.DESCRIPCION = row["DESCRIPCION"].ToString();
						RespuestaComun.lstCatalogo.Add(itemLector);
					}
					return RespuestaComun;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
				throw new Exception(ex.Message);
			}
		}

		public RespuestaComunBE AddCatEspecifico(CatGeneralesBE itemCatGenerales, string sDescripcion)
		{
			RespuestaComunBE RespuestaComun = new RespuestaComunBE();
			_ = string.Empty;
			RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
			RespuestaComun.itemError = new ErrorBE();
			RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spAddCatGenerales")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@NOMBRECATALOGO", MySqlDbType.Int64).Value = itemCatGenerales.psIDCATGENERALES;
				dbCommand.Parameters.Add("@IDCATALOGO", MySqlDbType.Int64).Value = itemCatGenerales.psIDCATGENERALES;
				dbCommand.Parameters.Add("@DESCRIPCION", MySqlDbType.Int64).Value = itemCatGenerales.psIDCATGENERALES;
				dbCommand.Parameters.Add("@VALORDESCRIPCION", MySqlDbType.Int64).Value = itemCatGenerales.psIDCATGENERALES;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						CatalogosBE itemLector = new CatalogosBE();
						itemLector.ID = row["RESPUESTA"].ToString();
						RespuestaComun.lstCatalogo.Add(itemLector);
					}
					return RespuestaComun;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
				throw new Exception(ex.Message);
			}
		}

		public RespuestaComunBE SetCatEspecifico(CatGeneralesBE item)
		{
			RespuestaComunBE RespuestaComun = new RespuestaComunBE();
			_ = string.Empty;
			RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
			RespuestaComun.itemError = new ErrorBE();
			RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spSetCatEspecifico")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDCATGENERALES", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@NOMBRECATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@IDCATALOGO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@DESCRIPCION", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@FILTRO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				dbCommand.Parameters.Add("@ACTIVO", MySqlDbType.Int64).Value = item.psIDCATGENERALES;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
					}
					return RespuestaComun;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
				throw new Exception(ex.Message);
			}
		}

		public RespuestaComunBE GetConfigAPP(ConfiguracionBE item)
		{
			RespuestaComunBE RespuestaComun = new RespuestaComunBE();
			_ = string.Empty;
			RespuestaComun.lstConfiguracion = new List<ConfiguracionBE>();
			RespuestaComun.itemError = new ErrorBE();
			RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spGetConfigApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDCONFIGAPP", MySqlDbType.Int64).Value = item.psIDCONFIGAPP;
				ConfiguracionBE itemLector = new ConfiguracionBE();
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					{
						IEnumerator enumerator = DataTable.Rows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								DataRow row = (DataRow)enumerator.Current;
								itemLector.psIDCONFIGAPP = row["IDCONFIGAPP"].ToString();
								itemLector.psDESCRIPCION = row["DESCRIPCION"].ToString();
								itemLector.psVALOR = row["VALOR"].ToString();
								itemLector.psACTIVO = row["ACTIVO"].ToString();
								RespuestaComun.lstConfiguracion.Add(itemLector);
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
					return RespuestaComun;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
				throw new Exception(ex.Message);
			}
		}

		public RespuestaComunBE AddConfigAPP(ConfiguracionBE item)
		{
			RespuestaComunBE RespuestaComun = new RespuestaComunBE();
			_ = string.Empty;
			RespuestaComun.lstConfiguracion = new List<ConfiguracionBE>();
			RespuestaComun.itemError = new ErrorBE();
			RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spAddConfigApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@DESCRIPCION", MySqlDbType.Int64).Value = item.psDESCRIPCION;
				dbCommand.Parameters.Add("@VALOR", MySqlDbType.Int64).Value = item.psVALOR;
				dbCommand.Parameters.Add("@ACTIVO", MySqlDbType.Int64).Value = item.psACTIVO;
				new ConfiguracionBE();
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					{
						IEnumerator enumerator = DataTable.Rows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								DataRow row = (DataRow)enumerator.Current;
								RespuestaComun.psIDCONFIGAPP = row["IDCONFIGAPPNEW"].ToString();
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
					return RespuestaComun;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
				throw new Exception(ex.Message);
			}
		}

		public RespuestaComunBE SetConfigAPP(ConfiguracionBE item)
		{
			RespuestaComunBE RespuestaComun = new RespuestaComunBE();
			_ = string.Empty;
			RespuestaComun.lstConfiguracion = new List<ConfiguracionBE>();
			RespuestaComun.itemError = new ErrorBE();
			RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spSetConfigApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@IDCONFIGAPP", MySqlDbType.Int64).Value = item.psDESCRIPCION;
				dbCommand.Parameters.Add("@DESCRIPCION", MySqlDbType.Int64).Value = item.psDESCRIPCION;
				dbCommand.Parameters.Add("@VALOR", MySqlDbType.Int64).Value = item.psVALOR;
				dbCommand.Parameters.Add("@ACTIVO", MySqlDbType.Int64).Value = item.psACTIVO;
				new ConfiguracionBE();
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					{
						IEnumerator enumerator = DataTable.Rows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								DataRow row = (DataRow)enumerator.Current;
								RespuestaComun.psIDCONFIGAPP = row["IDCONFIGAPPNEW"].ToString();
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
					return RespuestaComun;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
				throw new Exception(ex.Message);
			}
		}

		public void insErrorDB(string MessageErr, StackTrace st, string user, string sApp)
		{
			try
			{
				if (MessageErr.Length > 445)
				{
					MessageErr = MessageErr.Substring(0, 445);
				}
				string strHostname = Dns.GetHostName();
				string sIp = Dns.GetHostEntry(strHostname).AddressList.Where((IPAddress n) => n.AddressFamily == AddressFamily.InterNetwork).First().ToString();
				StringBuilder strStackTrace = new StringBuilder();
				StackFrame[] frames = st.GetFrames();
				int num = 0;
				if (num < frames.Length)
				{
					StackFrame f = frames[num];
					strStackTrace.Append(f.ToString());
				}
				if (strStackTrace.Length > 490)
				{
					string sStackTrace = strStackTrace.ToString();
					strStackTrace.Clear();
					strStackTrace.Append(sStackTrace.Substring(0, 490));
				}
				if (sIp.Length > 39)
				{
					sIp = sIp.Substring(0, 39);
				}
				if (strHostname.Length > 148)
				{
					strHostname = strHostname.Substring(0, 148);
				}
				MySqlCommand dbCommand = new MySqlCommand("sp_insLogError")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@idApp", MySqlDbType.Int64).Value = long.Parse(sApp);
				dbCommand.Parameters.Add("@MENSAJE", MySqlDbType.Int64).Value = MessageErr;
				dbCommand.Parameters.Add("@HOSTNAME", MySqlDbType.Int64).Value = strHostname;
				dbCommand.Parameters.Add("@IP", MySqlDbType.Int64).Value = sIp;
				dbCommand.Parameters.Add("@STACKTRACE", MySqlDbType.Int64).Value = strStackTrace.ToString();
				dbCommand.Parameters.Add("@DTFECHAERROR", MySqlDbType.Int64).Value = DateTime.Now;
				dbCommand.Parameters.Add("@VCHUSUARIO", MySqlDbType.Int64).Value = user;
				if (!ExecuteNonQuery(ref dbCommand, out var _, out var dbError))
				{
					throw new DbDataContextException(dbError);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}

}
