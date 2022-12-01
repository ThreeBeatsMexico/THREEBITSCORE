﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Business.Security.Common
{
    public class CommonBR
    {
        string sConnGral = ConfigurationManager.AppSettings["ConnGral"].ToString();
        public RespuestaComunBE GetDefinicionTabla(string sNombreTabla)
        {
            CommonDA oCommonDA = new CommonDA();
            ConfigurationDA oConfiguracionDA = new ConfigurationDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();
            List<CatalogosBE> lsCatalogos = new List<CatalogosBE>();


            string sConexionString = string.Empty;

            itemConfig.psIDCONFIGAPP = ConfigurationManager.AppSettings["IdCatConexionString"].ToString();

            Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig, sConnGral);
            sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

            Respuesta = oCommonDA.GetDefinicionTabla(sNombreTabla, sConexionString);

            return Respuesta;
        }
    }
}
