using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Business.Security;
using ThreeBits.Business.User;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.Security;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security;
using ThreeBits.Shared;

namespace ThreeBits.Services.Security
{
    public class SecurityService: _BaseService, ISecurityService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly ISecurityBR _serviceBr;

        public SecurityService(ILogger<SecurityService> logger,
                       
            IConfiguration configuration,
            ISecurityBR service)
        {
            _logger = logger;
            _configuration = configuration;
            _serviceBr = service;
        }
        
        public ProcessResult Authenticate(Credential oCredential)
        {
            AplicacionBE oAppBE = new AplicacionBE();
            string sIdApp = _configuration["TBSettings:IdApp"];
            string sPasswordApp = _configuration["TBSettings:PasswordApp"];

            DataTable odata = new DataTable();
            Credential CredentialRes = new Credential();
            ProcessResult oRes = new ProcessResult();
            UsersBR oUser = new UsersBR();
           // SecurityBR oSecBr = new SecurityBR();
            ReglasBE reglas = new ReglasBE();
            DatosUsuarioBE resUsuario = new DatosUsuarioBE();
            int iTpoBusqueda = oCredential.tipoBusqueda.HasValue ? Convert.ToInt32(oCredential.tipoBusqueda) : 3;
            odata = _serviceBr.getAppInfo(oCredential.xAppId.ToString());
            reglas.TIPOBUSQUEDA = iTpoBusqueda;
            reglas.USUARIO = oCredential.userName;
            reglas.IDAPP = oAppBE.IDAPLICACION;
            resUsuario = oUser.getUsuarioFull(reglas, long.Parse(sIdApp));
            oRes.flag = false;

            if (resUsuario.Usuario.IDUSUARIO.ToString() == "0")
            {
                oRes.errorMessage = "El Nombre de usuario no existe!";
            }
            else if (resUsuario.Usuario.ACTIVO == false)
            {
                oRes.errorMessage = "El usuario se encuentra intactivo, debes activarlo desde tu cuenta correo registrada";
            }
            else
            {
               // SecurityBR oSecBR = new SecurityBR();
                EncryptionBE ResDecrypt = new EncryptionBE();
                string sUserPasswordBD = string.Empty;
                ResDecrypt = _serviceBr.encryptDesEncrypt(2, resUsuario.Usuario.PASSWORD, long.Parse(sIdApp));
                sUserPasswordBD = ResDecrypt.VALOROUT.ToString();
                Utils oUtils = new Utils();
                if (oUtils.ValidaPassword(oCredential.password, sUserPasswordBD))
                {
                    CredentialRes.name = resUsuario.Usuario.NOMBRE;
                    CredentialRes.idUser = resUsuario.Usuario.IDUSUARIO.ToString();

                    switch (iTpoBusqueda)
                    {
                        case 1:
                            CredentialRes.userName = resUsuario.Usuario.IDUSUARIO.ToString();
                            break;
                        case 2:
                            CredentialRes.userName = resUsuario.Usuario.IDUSUARIOAPP;
                            break;
                        case 3:
                            CredentialRes.userName = resUsuario.Usuario.USUARIO;
                            break;
                        default:
                            CredentialRes.userName = resUsuario.Usuario.USUARIO;
                            break;
                    }


                    CredentialRes.rolId = resUsuario.Usuario.IDUSUARIO.ToString();
                    oRes.flag = true;
                    oRes.data = CredentialRes;
                }
                else { oRes.errorMessage = "El Password es incorrecto!"; }
            }

            return oRes;


        }

        public TokenJwt CreaToken(Credential cred)
        {
            TokenJwt oToken = new TokenJwt();
            AplicacionBE oAppBE = new AplicacionBE();
            try
            {
                //int expireMinutes = oAppBE.jwtExpirationTime;
                //string token = JwtManager.GenerateToken(cred.userName, cred.name, cred.idUser.ToString(), cred.rolId, oAppBE.jwtKey, expireMinutes);
                //string tokenRefresh = JwtManager.GenerateTokenRefresh(cred.userName, cred.name, cred.idUser.ToString(), cred.rolId, "", oAppBE.jwtKey, expireMinutes);
                //oToken.profileId = cred.rolId;
                //oToken.userId = cred.userName;
                //oToken.tokenId = token;
                //oToken.tokenRefresh = tokenRefresh;
            }
            catch (Exception ex)
            {
            }
            return oToken;
        }
    }
}
