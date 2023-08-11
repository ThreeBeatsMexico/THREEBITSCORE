using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.Security;
using ThreeBits.Interfaces.Security.Security;

namespace ThreeBits.Services.Security
{
    public class JwtServiceManager:_BaseService, IJwtServiceManager
    {

        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISecurityServiceDA _securityServiceDA;

        public JwtServiceManager(ILogger<SecurityServiceBR> logger, IHttpContextAccessor httpContextAccessor , ISecurityServiceDA securityServiceDA)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _securityServiceDA = securityServiceDA;

        }


        public string GenerateToken(string username, string name, string userid, string roleid, string Secret, int expireMinutes = 900)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.UserData, name),
                            new Claim(ClaimTypes.NameIdentifier, userid),
                            new Claim(ClaimTypes.Role, roleid)
                        }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
                /*,
                Issuer = "self",
                Audience = "  "*/
            };


            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public string GenerateTokenRefresh(string username, string name, string userid, string roleid, string stringtoken, string SecretRefresh, int expireMinutes = 5)
        {
            var symmetricKey = Convert.FromBase64String(SecretRefresh);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow.AddMinutes(expireMinutes + 5);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.UserData, name),
                            new Claim(ClaimTypes.NameIdentifier, userid),
                            new Claim(ClaimTypes.Role, roleid),
                             new Claim(ClaimTypes.SerialNumber, stringtoken)
                        }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
                /*,
                Issuer = "self",
                Audience = "  "*/
            };


            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }


        public ClaimsPrincipal GetPrincipal(string token, string xAppId)
        {
            try
            {
                AplicacionBE oApp = new AplicacionBE();
                // SecurityDA oSecurityDA = new SecurityDA();
                oApp = _securityServiceDA.getAppInfoDat(xAppId);
                string Secret = oApp.jwtKey;
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        static string GetSessionValue(string tkn, string key)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwt = tokenHandler.ReadToken(tkn) as JwtSecurityToken;
            return jwt.Claims.FirstOrDefault(x => x.Type == key)?.Value;
        }

        public string GetToken()
        {
            //;
           // var request = HttpContext.Current.Request;
            Regex rgx = new Regex("Bearer\\s+");
            return rgx.Replace(_httpContextAccessor.HttpContext.Request.Headers["Authorization"], "");
        }

        public string GetUserId()
        {
            string tkn = GetToken();
            return GetSessionValue(tkn, "nameid");
        }

        public string GetProfileId()
        {
            string tkn = GetToken();
            return GetSessionValue(tkn, "role");
        }

        public string GetUsername()
        {
            string tkn = GetToken();
            return GetSessionValue(tkn, "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata");
        }

        public string GetName()
        {
            string tkn = GetToken();
            return GetSessionValue(tkn, "unique_name");
        }



        public bool ValidaRefresh(string tokenrefresh)
        {
            try
            {
                string token = GetToken();
                string tokenANT = Convert.ToString(GetSessionValue(tokenrefresh, "certserialnumber"));
                if (token == tokenANT)
                {

                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    JwtSecurityToken jwt = tokenHandler.ReadToken(tokenrefresh) as JwtSecurityToken;
                    var timeTokenIni = Convert.ToDateTime(jwt.ValidFrom);
                    var timeTokenFin = Convert.ToDateTime(jwt.ValidTo);


                    var now = DateTime.UtcNow.AddMinutes(-5);
                    var fin = DateTime.UtcNow.AddMinutes(5);

                    if (timeTokenIni >= now && timeTokenFin <= fin)
                    {
                        return true;
                    }
                    else

                    {
                        return false;
                    }


                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }


        }




    }
}
