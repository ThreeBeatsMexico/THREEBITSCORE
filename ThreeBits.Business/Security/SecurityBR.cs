using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
using ThreeBits.Interfaces.Security;

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

        public EncryptionBE encryptDesEncrypt(int Tipo, string Valor, Int64 App)
        {
            try
            {
               // EncryptDecryptSecVB CrypDecrypt = new EncryptDecryptSecVB();
                EncryptionBE Encriptacion = new EncryptionBE();
                if (Tipo == 1) ////Encrypta
                {
                    Encriptacion.VALORIN = Valor;
                   // Encriptacion.VALOROUT = CrypDecrypt.EncryptString(Valor, "");
                }
                else ///Desencrypta
                {
                    Encriptacion.VALORIN = Valor;
                   // Encriptacion.VALOROUT = CrypDecrypt.DecryptString(Valor, "");
                }
                return Encriptacion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable getAppInfo(string xAppId)
        {
            try
            {
                //SecurityDA oSec = new SecurityDA();
                //return oSec.getAppInfoDat(xAppId);
                return _dataAccess.getAppInfoDat(xAppId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
