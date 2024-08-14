using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Common;
using ThreeBits.Interfaces.Common;
using static ThreeBits.Data.Common.SqlDataContext;

namespace ThreeBits.Services.Security.Common
{
	public class CommonServiceBR : SqlDataContext, ICommonServiceBR
	{
		private readonly ILogger _logger;

		private readonly ICommonServiceDA _commonServiceDA;

		private readonly IConfiguration _configuration;

		public string _sIdApp;

		public CommonServiceBR(ILogger<CommonServiceBR> logger, ICommonServiceDA commonServiceDA, IConfiguration configuration)
		{
			_logger = logger;
			_commonServiceDA = commonServiceDA;
			_configuration = configuration;
			_sIdApp = _configuration["TBSettings:IdApp"];
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
				SqlCommand dbCommand = new SqlCommand("sp_insLogError")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("@idApp", SqlDbType.BigInt).Value = long.Parse(sApp);
				dbCommand.Parameters.Add("@MENSAJE", SqlDbType.BigInt).Value = MessageErr;
				dbCommand.Parameters.Add("@HOSTNAME", SqlDbType.BigInt).Value = strHostname;
				dbCommand.Parameters.Add("@IP", SqlDbType.BigInt).Value = sIp;
				dbCommand.Parameters.Add("@STACKTRACE", SqlDbType.BigInt).Value = strStackTrace.ToString();
				dbCommand.Parameters.Add("@DTFECHAERROR", SqlDbType.BigInt).Value = DateTime.Now;
				dbCommand.Parameters.Add("@VCHUSUARIO", SqlDbType.BigInt).Value = user;
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

		public RespuestaComunBE GetConfigAPP(ConfiguracionBE item)
		{
			new RespuestaComunBE();
			new ConfiguracionBE();
			return _commonServiceDA.GetConfigAPP(item);
		}

		public RespuestaComunBE AddConfigAPP(ConfiguracionBE item)
		{
			new RespuestaComunBE();
			new ConfiguracionBE();
			_ = string.Empty;
			return _commonServiceDA.AddConfigAPP(item);
		}

		public RespuestaComunBE SetConfigAPP(ConfiguracionBE item)
		{
			new RespuestaComunBE();
			new ConfiguracionBE();
			_ = string.Empty;
			return _commonServiceDA.SetConfigAPP(item);
		}

		public RespuestaComunBE GetCatGenerales(CatGeneralesBE item)
		{
			new RespuestaComunBE();
			new ConfiguracionBE();
			return _commonServiceDA.GetCatGenerales(item);
		}

		public RespuestaComunBE AddCatGenerales(CatGeneralesBE item)
		{
			new RespuestaComunBE();
			new ConfiguracionBE();
			return _commonServiceDA.AddCatGenerales(item);
		}

		public RespuestaComunBE SetCatGenerales(CatGeneralesBE item)
		{
			new RespuestaComunBE();
			new ConfiguracionBE();
			return _commonServiceDA.SetCatGenerales(item);
		}

		public RespuestaComunBE GetCatEspecifico(string sIdCatalogo, string sValorFiltro = "")
		{
			CatGeneralesBE item = new CatGeneralesBE();
			RespuestaComunBE Respuesta = new RespuestaComunBE();
			ConfiguracionBE itemConfig = new ConfiguracionBE();
			Respuesta = _commonServiceDA.GetConfigAPP(itemConfig);
			Respuesta = GetCatGenerales(item);
			return _commonServiceDA.GetCatEspecifico(Respuesta.lstCatGenerales[0]);
		}

		public RespuestaComunBE AddCatEspecifico(string sIdCatalogo, string sDescripcion)
		{
			CatGeneralesBE item = new CatGeneralesBE();
			RespuestaComunBE Respuesta = new RespuestaComunBE();
			ConfiguracionBE itemConfig = new ConfiguracionBE();
			Respuesta = _commonServiceDA.GetConfigAPP(itemConfig);
			Respuesta = GetCatGenerales(item);
			return _commonServiceDA.AddCatEspecifico(Respuesta.lstCatGenerales[0], sDescripcion);
		}
	}
}
