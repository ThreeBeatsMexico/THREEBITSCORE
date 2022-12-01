using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;

namespace ThreeBits.Interfaces.Security.Common
{
    internal interface IConfiguracionBR
    {

        RespuestaComunBE GetConfigAPP(ConfiguracionBE item);
        RespuestaComunBE AddConfigAPP(ConfiguracionBE item);
        RespuestaComunBE SetConfigAPP(ConfiguracionBE item);
    }
}
