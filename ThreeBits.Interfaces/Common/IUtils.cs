using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;

namespace ThreeBits.Interfaces.Common
{
    public interface IUtils
    {
        bool ValidaExpresion(string sTexto, string sPatron);
        bool ValidaPassword(string sPassword, string sPasswordBD);
        ProcessResult ValidaDatosMiPortal(string sEmail, string sTel, string sPassword, string sCPassword);
        ProcessResult ValidaDatos(string sEmail, string sPassword, string sCPassword, bool bAplicaSeguridadPassword, bool bConciciones = true);

        void writeLogFile(LogFileBE item);

    }
}
