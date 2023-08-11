using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Common;
using ThreeBits.Interfaces.Security.Common;

namespace ThreeBits.Services.Security.Common
{
    public class CommonServiceDA : SqlDataContext, ICommonServiceDA
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        //  private readonly ISecurityCommonDA _securityCommon;

        public CommonServiceDA(ILogger<CommonServiceDA> logger,

            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            // _securityCommon = securityCommonDA;
        }



        /// <summary>
        /// Consulta de la tabla CatGenerales. Definición de todos los catalogos de la aplicación
        /// </summary>
        /// <param name="item">Se usa CatGeneralesBE.psIDCATGENERALES para la consulta, de no ser proporcionado regresa Resultados sin filtro</param>
        /// <param name="sConexionString">cadena de conexión que se obtiene de la clase ConfiguracionDA</param>
        /// <returns>RespuestaComun.lstCatGenerales</returns>
        public RespuestaComunBE GetCatGenerales(CatGeneralesBE item)
        {

            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            string sResultado = string.Empty;

            RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
            RespuestaComun.itemError = new ErrorBE();
            RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);

            try
            {
                var dbCommand = new SqlCommand("spGetCatGenerales")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDCATGENERALES", SqlDbType.BigInt).Value = item.psIDCATGENERALES;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
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
                       // break;
                    }
                }
                else throw new DbDataContextException(dbError);



                return RespuestaComun;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                this.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Agrega la tabla CatGenerales. Definición de todos los catalogos de la aplicación
        /// </summary>
        /// <param name="item">Se usa CatGeneralesBE Total mente llena para insertar</param>
        /// <param name="sConexionString">cadena de conexión que se obtiene de la clase ConfiguracionDA</param>
        /// <returns>RespuestaComun.lstCatGenerales</returns>
        public RespuestaComunBE AddCatGenerales(CatGeneralesBE item)
        {

            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            string sResultado = string.Empty;

            RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
            RespuestaComun.itemError = new ErrorBE();
            RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);

            try
            {
                var dbCommand = new SqlCommand("spAddCatGenerales")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@NOMBRECATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@IDCATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@FILTRO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@NOMBRECATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
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
                        // break;
                    }
                }
                else throw new DbDataContextException(dbError);



                return RespuestaComun;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                this.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza la tabla CatGenerales. Definición de todos los catalogos de la aplicación
        /// </summary>
        /// <param name="item">Se usa CatGeneralesBE Total mente llena para insertar</param>
        /// <param name="sConexionString">cadena de conexión que se obtiene de la clase ConfiguracionDA</param>
        /// <returns>RespuestaComun.lstCatGenerales</returns>
        public RespuestaComunBE SetCatGenerales(CatGeneralesBE item)
        {
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            string sResultado = string.Empty;

            RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
            RespuestaComun.itemError = new ErrorBE();
            RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);

            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spSetCatGenerales")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@NOMBRECATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@IDCATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@FILTRO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@NOMBRECATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
                return RespuestaComun;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);

                this.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
                throw new Exception(ex.Message);
            }

           

          
        }

        /// <summary>
        /// Consulta de catalogo espeficico. Definición de todos los catalogos de la aplicación
        /// </summary>
        /// <param name="item">Se usa CatGeneralesBE para la consulta, Se requiere el idCatGenerales</param>
        /// <param name="sConexionString">cadena de conexión que se obtiene de la clase ConfiguracionDA</param>
        /// <returns>RespuestaComun.lstCatGenerales</returns>
        public RespuestaComunBE GetCatEspecifico(CatGeneralesBE item)
        {
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            string sResultado = string.Empty;

            RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
            RespuestaComun.itemError = new ErrorBE();
            RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);

            try
            {
                var dbCommand = new SqlCommand("spGetCatEspecifico")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDCATGENERALES", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@NOMBRECATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@IDCATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@FILTRO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@VALORFILTRO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        CatalogosBE itemLector = new CatalogosBE();

                        itemLector.ID = row["ID"].ToString();
                        itemLector.DESCRIPCION = row["DESCRIPCION"].ToString();

                        RespuestaComun.lstCatalogo.Add(itemLector);
                        // break;
                    }
                }
                else throw new DbDataContextException(dbError);



                return RespuestaComun;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                this.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
                throw new Exception(ex.Message);
            }
               
        }
        /// <summary>
        /// Agrega catalogo espeficico. Definición de todos los catalogos de la aplicación
        /// </summary>
        /// <param name="itemCatGenerales">Se usa CatGeneralesBE Total mente llena para insertar</param>
        /// <param name="sConexionString">cadena de conexión que se obtiene de la clase ConfiguracionDA</param>
        /// <returns>RespuestaComun.lstCatGenerales</returns>
        public RespuestaComunBE AddCatEspecifico(CatGeneralesBE itemCatGenerales, string sDescripcion)
        {
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            string sResultado = string.Empty;

            RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
            RespuestaComun.itemError = new ErrorBE();
            RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);

            try
            {
                var dbCommand = new SqlCommand("spAddCatGenerales")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@NOMBRECATALOGO", SqlDbType.BigInt).Value = itemCatGenerales.psIDCATGENERALES;
                dbCommand.Parameters.Add("@IDCATALOGO", SqlDbType.BigInt).Value = itemCatGenerales.psIDCATGENERALES;
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.BigInt).Value = itemCatGenerales.psIDCATGENERALES;
                dbCommand.Parameters.Add("@VALORDESCRIPCION", SqlDbType.BigInt).Value = itemCatGenerales.psIDCATGENERALES;
            
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        CatalogosBE itemLector = new CatalogosBE();

                        itemLector.ID = row["RESPUESTA"].ToString();
                      

                        RespuestaComun.lstCatalogo.Add(itemLector);
                        // break;
                    }
                }
                else throw new DbDataContextException(dbError);



                return RespuestaComun;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                this.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
                throw new Exception(ex.Message);
            }
              
        }
        /// <summary>
        /// Actualiza catalogo espeficico. Definición de todos los catalogos de la aplicación
        /// </summary>
        /// <param name="item">Se usa CatGeneralesBE Total mente llena para insertar</param>
        /// <param name="sConexionString">cadena de conexión que se obtiene de la clase ConfiguracionDA</param>
        /// <returns>RespuestaComun.lstCatGenerales</returns>
        public RespuestaComunBE SetCatEspecifico(CatGeneralesBE item)
        {
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            string sResultado = string.Empty;

            RespuestaComun.lstCatGenerales = new List<CatGeneralesBE>();
            RespuestaComun.itemError = new ErrorBE();
            RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);

            try
            {
                bool bFlag = true;
                var dbCommand = new SqlCommand("spSetCatEspecifico")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDCATGENERALES", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@NOMBRECATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@IDCATALOGO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@FILTRO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.BigInt).Value = item.psIDCATGENERALES;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                        bFlag = true;
                    else
                        bFlag = false;
                }
                else throw new DbDataContextException(dbError);
                return RespuestaComun;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);

                this.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
                throw new Exception(ex.Message);
            }

           

             

           
        }

        public RespuestaComunBE GetConfigAPP(ConfiguracionBE item)
        {

            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            string sResultado = string.Empty;

            RespuestaComun.lstConfiguracion = new List<ConfiguracionBE>();
            RespuestaComun.itemError = new ErrorBE();
            RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);

            try
            {
                var dbCommand = new SqlCommand("spGetConfigApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDCONFIGAPP", SqlDbType.BigInt).Value = item.psIDCONFIGAPP;

                ConfiguracionBE itemLector = new ConfiguracionBE();




                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        itemLector.psIDCONFIGAPP = row["IDCONFIGAPP"].ToString();
                        itemLector.psDESCRIPCION = row["DESCRIPCION"].ToString();
                        itemLector.psVALOR = row["VALOR"].ToString();
                        itemLector.psACTIVO = row["ACTIVO"].ToString();
                        RespuestaComun.lstConfiguracion.Add(itemLector);
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);



                return RespuestaComun;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                this.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
                throw new Exception(ex.Message);
            }
        }



           
          
                       
                  
        public RespuestaComunBE AddConfigAPP(ConfiguracionBE item)
        {

            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            string sResultado = string.Empty;

            RespuestaComun.lstConfiguracion = new List<ConfiguracionBE>();
            RespuestaComun.itemError = new ErrorBE();
            RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);

            try
            {
                var dbCommand = new SqlCommand("spAddConfigApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.BigInt).Value = item.psDESCRIPCION;
                dbCommand.Parameters.Add("@VALOR", SqlDbType.BigInt).Value = item.psVALOR;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.BigInt).Value = item.psACTIVO;
              


                ConfiguracionBE itemLector = new ConfiguracionBE();




                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {

                        RespuestaComun.psIDCONFIGAPP = row["IDCONFIGAPPNEW"].ToString();
                     
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);



                return RespuestaComun;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                this.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
                throw new Exception(ex.Message);
            }




               
        }
        public RespuestaComunBE SetConfigAPP(ConfiguracionBE item)
        {
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            string sResultado = string.Empty;

            RespuestaComun.lstConfiguracion = new List<ConfiguracionBE>();
            RespuestaComun.itemError = new ErrorBE();
            RespuestaComun.itemError.psMensaje = new StringBuilder(string.Empty);

            try
            {
                var dbCommand = new SqlCommand("spSetConfigApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDCONFIGAPP", SqlDbType.BigInt).Value = item.psDESCRIPCION;
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.BigInt).Value = item.psDESCRIPCION;
                dbCommand.Parameters.Add("@VALOR", SqlDbType.BigInt).Value = item.psVALOR;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.BigInt).Value = item.psACTIVO;



                ConfiguracionBE itemLector = new ConfiguracionBE();




                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {

                        RespuestaComun.psIDCONFIGAPP = row["IDCONFIGAPPNEW"].ToString();

                        break;
                    }
                }
                else throw new DbDataContextException(dbError);



                return RespuestaComun;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                this.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "1");
                throw new Exception(ex.Message);
            }
          
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

    }
}
