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
	public class JwtServiceManager : _BaseService, IJwtServiceManager
	{
		private readonly ILogger _logger;

		private readonly IHttpContextAccessor _httpContextAccessor;

		private readonly ISecurityServiceDA _securityServiceDA;

		public JwtServiceManager(ILogger<SecurityServiceBR> logger, IHttpContextAccessor httpContextAccessor, ISecurityServiceDA securityServiceDA)
		{
			_logger = logger;
			_httpContextAccessor = httpContextAccessor;
			_securityServiceDA = securityServiceDA;
		}

		public string GenerateToken(string username, string name, string userid, string roleid, string Secret, int expireMinutes = 900)
		{
			byte[] symmetricKey = Convert.FromBase64String(Secret);
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			DateTime now = DateTime.UtcNow;
			SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
			securityTokenDescriptor.Subject = new ClaimsIdentity(new Claim[4]
			{
			new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username),
			new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", name),
			new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userid),
			new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", roleid)
			});
			securityTokenDescriptor.Expires = now.AddMinutes(Convert.ToInt32(expireMinutes));
			securityTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256");
			SecurityTokenDescriptor tokenDescriptor = securityTokenDescriptor;
			SecurityToken stoken = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(stoken);
		}

		public string GenerateTokenRefresh(string username, string name, string userid, string roleid, string stringtoken, string SecretRefresh, int expireMinutes = 5)
		{
			byte[] symmetricKey = Convert.FromBase64String(SecretRefresh);
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			DateTime now = DateTime.UtcNow.AddMinutes(expireMinutes + 5);
			SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
			securityTokenDescriptor.Subject = new ClaimsIdentity(new Claim[5]
			{
			new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username),
			new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", name),
			new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userid),
			new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", roleid),
			new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber", stringtoken)
			});
			securityTokenDescriptor.Expires = now.AddMinutes(Convert.ToInt32(expireMinutes));
			securityTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256");
			SecurityTokenDescriptor tokenDescriptor = securityTokenDescriptor;
			SecurityToken stoken = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(stoken);
		}

		public ClaimsPrincipal GetPrincipal(string token, string xAppId)
		{
			try
			{
				new AplicacionBE();
				string Secret = _securityServiceDA.getAppInfoDat(xAppId).jwtKey;
				JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
				if (!(((TokenHandler)tokenHandler).ReadToken(token) is JwtSecurityToken))
				{
					return null;
				}
				byte[] symmetricKey = Convert.FromBase64String(Secret);
				TokenValidationParameters validationParameters = new TokenValidationParameters
				{
					RequireExpirationTime = true,
					ValidateIssuer = false,
					ValidateAudience = false,
					IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
				};
				SecurityToken securityToken;
				return tokenHandler.ValidateToken(token, validationParameters, out securityToken);
			}
			catch (Exception)
			{
				throw;
			}
		}

		private static string GetSessionValue(string tkn, string key)
		{
			return (((TokenHandler)new JwtSecurityTokenHandler()).ReadToken(tkn) as JwtSecurityToken).Claims.FirstOrDefault((Claim x) => x.Type == key)?.Value;
		}

		public string GetToken()
		{
			return new Regex("Bearer\\s+").Replace(_httpContextAccessor.HttpContext.Request.Headers["Authorization"], "");
		}

		public string GetUserId()
		{
			return GetSessionValue(GetToken(), "nameid");
		}

		public string GetProfileId()
		{
			return GetSessionValue(GetToken(), "role");
		}

		public string GetUsername()
		{
			return GetSessionValue(GetToken(), "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata");
		}

		public string GetName()
		{
			return GetSessionValue(GetToken(), "unique_name");
		}

		public bool ValidaRefresh(string tokenrefresh)
		{
			try
			{
				string token = GetToken();
				string tokenANT = Convert.ToString(GetSessionValue(tokenrefresh, "certserialnumber"));
				if (token == tokenANT)
				{
					JwtSecurityToken obj = ((TokenHandler)new JwtSecurityTokenHandler()).ReadToken(tokenrefresh) as JwtSecurityToken;
					DateTime timeTokenIni = Convert.ToDateTime(obj.ValidFrom);
					DateTime timeTokenFin = Convert.ToDateTime(obj.ValidTo);
					DateTime now = DateTime.UtcNow.AddMinutes(-5.0);
					DateTime fin = DateTime.UtcNow.AddMinutes(5.0);
					if (timeTokenIni >= now && timeTokenFin <= fin)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}
	}
}
