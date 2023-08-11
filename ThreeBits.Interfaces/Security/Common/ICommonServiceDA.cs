using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;

namespace ThreeBits.Interfaces.Security.Common
{
    public interface ICommonServiceDA
    {
        void insErrorDB(string MessageErr, StackTrace st, string user, string sApp);

        RespuestaComunBE GetCatGenerales(CatGeneralesBE item);

        RespuestaComunBE AddCatGenerales(CatGeneralesBE item);

        RespuestaComunBE SetCatGenerales(CatGeneralesBE item);

        RespuestaComunBE GetCatEspecifico(CatGeneralesBE item);

        RespuestaComunBE AddCatEspecifico(CatGeneralesBE itemCatGenerales, string sDescripcion);
        RespuestaComunBE SetCatEspecifico(CatGeneralesBE item);
        RespuestaComunBE GetConfigAPP(ConfiguracionBE item);

        RespuestaComunBE AddConfigAPP(ConfiguracionBE item);
        RespuestaComunBE SetConfigAPP(ConfiguracionBE item);
    }
}
