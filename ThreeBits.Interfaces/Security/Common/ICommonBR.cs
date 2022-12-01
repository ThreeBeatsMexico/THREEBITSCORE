using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;

namespace ThreeBits.Interfaces.Security.Common
{
    internal interface ICommonBR
    {
        public RespuestaComunBE GetDefinicionTabla(string sNombreTabla);
    }

}
