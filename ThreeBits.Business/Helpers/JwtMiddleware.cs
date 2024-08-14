using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Business.Security.Security;
using ThreeBits.Entities.Security;
using ThreeBits.Interfaces.Security;
using ThreeBits.Interfaces.Security.Security;

namespace ThreeBits.Business.Helpers
{
	public class JwtMiddleware
	{
		private readonly RequestDelegate _next;

		public JwtMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, ISecurityServiceBR securityServiceBR)
		{
			string xAppId = context.Request.Headers["XAPPID"].FirstOrDefault()?.Split(" ").Last();
			string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
			AplicacionBE oApp = new AplicacionBE();
			try
			{
				if (xAppId != null)
				{
					oApp = securityServiceBR.getAppInfo(xAppId);
				}
			}
			catch
			{
				return;
			}
			if (token != null)
			{
				await attachUserToContext(context, token, oApp);
			}
			await _next(context);
		}

		private Task<IPrincipal> attachUserToContext(HttpContext context, string token, AplicacionBE oApp)
		{
			try
			{
				if (ValidateToken(token, oApp, out var username, out var name, out var userid, out var roleid))
				{
					IPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
				{
					new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username),
					new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", name),
					new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userid),
					new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", roleid)
				}, "Jwt"));
					context.Items["User"] = user.Identity.Name;
					return Task.FromResult(user);
				}
			}
			catch (Exception)
			{
				throw;
			}
			return Task.FromResult<IPrincipal>(null);
		}

		private bool ValidateToken(string token, AplicacionBE oApp, out string username, out string name, out string userid, out string roleid)
		{
			username = null;
			name = null;
			userid = null;
			roleid = null;
			try
			{
				ClaimsIdentity identity = JwtManager.GetPrincipal(token, oApp).Identity as ClaimsIdentity;
				if (identity == null)
				{
					return false;
				}
				if (!identity.IsAuthenticated)
				{
					return false;
				}
				username = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
				if (string.IsNullOrEmpty(username))
				{
					return false;
				}
				name = identity.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata")?.Value;
				if (string.IsNullOrEmpty(name))
				{
					return false;
				}
				userid = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
				if (string.IsNullOrEmpty(userid))
				{
					return false;
				}
				roleid = identity.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
				if (string.IsNullOrEmpty(roleid))
				{
					return false;
				}
				return true;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
