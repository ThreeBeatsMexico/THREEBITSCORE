using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Security;

namespace ThreeBits.Interfaces.Security
{
    public interface ISecurityBR
    {

        EncryptionBE encryptDesEncrypt(int Tipo, string Valor, Int64 App);
        DataTable getAppInfo(string xAppId);


    }
}
