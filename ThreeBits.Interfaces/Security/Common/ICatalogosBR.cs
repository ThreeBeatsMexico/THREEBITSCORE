using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;

namespace ThreeBits.Interfaces.Security.Common
{
    internal interface ICatalogosBR
    {
        RespuestaComunBE GetCatGenerales(CatGeneralesBE item);
        RespuestaComunBE AddCatGenerales(CatGeneralesBE item);
        RespuestaComunBE SetCatGenerales(CatGeneralesBE item);
        RespuestaComunBE GetCatEspecifico(string sIdCatalogo, string sValorFiltro = "");
        RespuestaComunBE AddCatEspecifico(string sIdCatalogo, string sDescripcion);
    }
}
