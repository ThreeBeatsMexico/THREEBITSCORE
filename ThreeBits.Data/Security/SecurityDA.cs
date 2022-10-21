using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.Security;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace ThreeBits.Data.Security

{
   
    public class SecurityDA : SqlDataContext, ISecurityDA
    {

        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public SecurityDA(ILogger<SecurityDA> logger,

            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
       

        _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        }


        //public AplicacionBE getAppInfoDat(string xAppId)
        //{
        //    try
        //    {
              
               
        //        AplicacionBE sRes = new AplicacionBE();
        //        var Consulta = GetDynamicResult(" exec spGetAppInfo @xAppId", new SqlParameter("@xappid", xAppId));
        //        foreach (var s in Consulta)
        //        {
        //            sRes.IDAPLICACION = s.IDAPLICACION;
        //            sRes.DESCRIPCION = s.DESCRIPCION;
        //            sRes.PASSWORD = s.PASSWORD;
        //            sRes.jwtKey = s.JWTKEY;
        //            sRes.jwtExpirationTime = Convert.ToInt32(s.JWTEXPIRATIONTIME);
        //            sRes.URLINICIO = s.URLINICIO;
        //        }
        //        return sRes;
        //    }
        //    catch (Exception ex)
        //    {
        //        StackTrace st = new StackTrace(true);
        //        //CommonDA ComunDA = new CommonDA();
        //        //ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
        //        throw new Exception(ex.Message);
        //    }
        //}

        public DataTable getAppInfoDat(string xAppId)
        {
            var dbCommand = new SqlCommand("spGetAppInfo")
            {
                CommandType = CommandType.StoredProcedure
            };

            dbCommand.Parameters.Add("@xAppId", SqlDbType.VarChar).Value = xAppId;
          

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError)) return DataTable;
            else throw new DbDataContextException(dbError);
        }



    }
}
