using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Common;
using ThreeBits.Interfaces.Security.Common;

namespace ThreeBits.Services.Security.Common
{
    public class CommonServiceBR: SqlDataContext, ICommonServiceBR
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
                if (MessageErr.Length > 445) MessageErr = MessageErr.Substring(0, 445);
                //Obtiene el hostname
                String strHostname = Dns.GetHostName();
                IPHostEntry myself = Dns.GetHostEntry(strHostname);

                ////Obtiene la Ip del usuario que genero el error
                System.Net.IPAddress ip = myself.AddressList.Where(n => n.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
                string sIp = ip.ToString();

                StringBuilder strStackTrace = new StringBuilder();
                foreach (StackFrame f in st.GetFrames())
                {
                    strStackTrace.Append(f.ToString());
                    break;
                }

                //if (MessageErr.Length > 490) MessageErr = MessageErr.Substring(0, 448);

                if (strStackTrace.Length > 490)// Validamos la longitud del stack
                {
                    string sStackTrace = strStackTrace.ToString();
                    strStackTrace.Clear();
                    strStackTrace.Append(sStackTrace.Substring(0, 490));
                }

                if (sIp.Length > 39) sIp = sIp.Substring(0, 39);
                if (strHostname.Length > 148) strHostname = strHostname.Substring(0, 148);

                //Inserta en la tabla del log de errores


                var dbCommand = new SqlCommand("sp_insLogError")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@idApp", SqlDbType.BigInt).Value = Int64.Parse(sApp);
                dbCommand.Parameters.Add("@MENSAJE", SqlDbType.BigInt).Value = MessageErr;
                dbCommand.Parameters.Add("@HOSTNAME", SqlDbType.BigInt).Value = strHostname;
                dbCommand.Parameters.Add("@IP", SqlDbType.BigInt).Value = sIp;
                dbCommand.Parameters.Add("@STACKTRACE", SqlDbType.BigInt).Value = strStackTrace.ToString();
                dbCommand.Parameters.Add("@DTFECHAERROR", SqlDbType.BigInt).Value = DateTime.Now;
                dbCommand.Parameters.Add("@VCHUSUARIO", SqlDbType.BigInt).Value = user;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {                  
                }
                else throw new DbDataContextException(dbError);


              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RespuestaComunBE GetConfigAPP(ConfiguracionBE item)
        {
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            Respuesta = _commonServiceDA.GetConfigAPP(item);

            return Respuesta;
        }
        public RespuestaComunBE AddConfigAPP(ConfiguracionBE item)
        {
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            string sConexionString = string.Empty;
            Respuesta = _commonServiceDA.AddConfigAPP(item);

            return Respuesta;
        }
        public RespuestaComunBE SetConfigAPP(ConfiguracionBE item)
        {
           
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP = ConfigurationManager.AppSettings["IdCatConexionString"].ToString();

            //Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            //sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

            Respuesta = _commonServiceDA.SetConfigAPP(item);

            return Respuesta;
        }

        public RespuestaComunBE GetCatGenerales(CatGeneralesBE item)
        {
            //CatalogosDA oCatalogosDA = new CatalogosDA();
            //ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            //string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP = ConfigurationManager.AppSettings["IdCatConexionString"].ToString();

            //Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            //sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

            Respuesta = _commonServiceDA.GetCatGenerales(item);

            return Respuesta;
        }
        public RespuestaComunBE AddCatGenerales(CatGeneralesBE item)
        {
            //CatalogosDA oCatalogosDA = new CatalogosDA();
            //ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            //string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP = ConfigurationManager.AppSettings["IdCatConexionString"].ToString();

            //Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            //sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

            Respuesta = _commonServiceDA.AddCatGenerales(item);

            return Respuesta;
        }
        public RespuestaComunBE SetCatGenerales(CatGeneralesBE item)
        {
            //CatalogosDA oCatalogosDA = new CatalogosDA();
            //ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            //string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP = ConfigurationManager.AppSettings["IdCatConexionString"].ToString();

            //Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            //sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

            Respuesta = _commonServiceDA.SetCatGenerales(item);

            return Respuesta;
        }


        public RespuestaComunBE GetCatEspecifico(string sIdCatalogo, string sValorFiltro = "")
        {
           // CatalogosDA oCatalogosDA = new CatalogosDA();
            CatGeneralesBE item = new CatGeneralesBE();
         //   ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();


            //string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP = ConfigurationManager.AppSettings["IdCatConexionString"].ToString();

            Respuesta = _commonServiceDA.GetConfigAPP(itemConfig);
           // sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

           // item.psIDCATGENERALES = sIdCatalogo;

            Respuesta = GetCatGenerales(item);

            //item = Respuesta.lstCatGenerales[0];
            //item.psVALORFILTRO = sValorFiltro;

            Respuesta = _commonServiceDA.GetCatEspecifico(Respuesta.lstCatGenerales[0]);

            return Respuesta;
        }
        public RespuestaComunBE AddCatEspecifico(string sIdCatalogo, string sDescripcion)
        {
           // CatalogosDA oCatalogosDA = new CatalogosDA();
            CatGeneralesBE item = new CatGeneralesBE();
          //  ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();


          //  string sConexionString = string.Empty;

          //  itemConfig.psIDCONFIGAPP = ConfigurationManager.AppSettings["IdCatConexionString"].ToString();

            Respuesta = _commonServiceDA.GetConfigAPP(itemConfig);
        //    sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

          //  item.psIDCATGENERALES = sIdCatalogo;

            Respuesta = GetCatGenerales(item);


            Respuesta = _commonServiceDA.AddCatEspecifico(Respuesta.lstCatGenerales[0], sDescripcion);

            return Respuesta;

        }




    }
}
