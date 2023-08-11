using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;

namespace ThreeBits.Interfaces.Security.Common
{
    public interface ICommonServiceBR
    {
        void insErrorDB(string MessageErr, StackTrace st, string user, string sApp);
        RespuestaComunBE GetCatGenerales(CatGeneralesBE item);
        RespuestaComunBE AddCatGenerales(CatGeneralesBE item);
        RespuestaComunBE SetCatGenerales(CatGeneralesBE item);
        RespuestaComunBE GetCatEspecifico(string sIdCatalogo, string sValorFiltro = "");
        RespuestaComunBE AddCatEspecifico(string sIdCatalogo, string sDescripcion);
        
        RespuestaComunBE GetConfigAPP(ConfiguracionBE item);
        
        RespuestaComunBE AddConfigAPP(ConfiguracionBE item);
        
        RespuestaComunBE SetConfigAPP(ConfiguracionBE item);

        
        //RespuestaComunBE GetDefinicionTabla(string sNombreTabla);
    }

}
