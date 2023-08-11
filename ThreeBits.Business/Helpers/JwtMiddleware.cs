using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Business.Security.Security;
using ThreeBits.Entities.Security;
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
            var xAppId = context.Request.Headers["XAPPID"].FirstOrDefault()?.Split(" ").Last();
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            AplicacionBE oApp = new AplicacionBE();
            try
            {
               
               

                if (xAppId != null) { oApp = securityServiceBR.getAppInfo(xAppId); }
                   // context.Response. = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

            }
            catch
            {
               // context.ErrorResult = new AuthenticationFailureResult("Missing header", request);
                return;
            }





            if (token != null)
                await attachUserToContext(context, token, oApp);

            await _next(context);
        }

        private Task<IPrincipal> attachUserToContext(HttpContext context, string token, AplicacionBE oApp)
        {
            string username;
            string name;
            string userid;
            string roleid;

            try
            {
                



                if (ValidateToken(token, oApp, out username, out name, out userid, out roleid))
                {
                    // based on username to get more information from database in order to build local identity
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.UserData, name),
                    new Claim(ClaimTypes.NameIdentifier, userid),
                    new Claim(ClaimTypes.Role, roleid),
                };

                    var identity = new ClaimsIdentity(claims, "Jwt");
                    IPrincipal user = new ClaimsPrincipal(identity);
                    context.Items["User"] = user.Identity.Name;
                    return Task.FromResult(user);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Task.FromResult<IPrincipal>(null);

            //try
            //{
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var key = Encoding.ASCII.GetBytes("secretp de a,pr");
            //    tokenHandler.ValidateToken(token, new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
            //        ClockSkew = TimeSpan.Zero
            //    }, out SecurityToken validatedToken);

            //    var jwtToken = (JwtSecurityToken)validatedToken;
            //    var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            //    // attach user to context on successful jwt validation
            //    context.Items["User"] = "Extraeisiaro";
            //        //userService.GetById(userId);
            //}
            //catch
            //{
            //    // do nothing if jwt validation fails
            //    // user is not attached to context so request won't have access to secure routes
            //}
        }

        private bool ValidateToken(string token, AplicacionBE oApp, out string username, out string name, out string userid, out string roleid)
        {
            username = null;
            name = null;
            userid = null;
            roleid = null;

            try
            {
               
                var simplePrinciple = JwtManager.GetPrincipal(token, oApp);
                var identity = simplePrinciple.Identity as ClaimsIdentity;

                if (identity == null)
                    return false;

                if (!identity.IsAuthenticated)
                    return false;

                var usernameClaim = identity.FindFirst(ClaimTypes.Name);
                username = usernameClaim?.Value;
                if (string.IsNullOrEmpty(username))
                    return false;

                var nameClaim = identity.FindFirst(ClaimTypes.UserData);
                name = nameClaim?.Value;
                if (string.IsNullOrEmpty(name))
                    return false;

                var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                userid = userIdClaim?.Value;
                if (string.IsNullOrEmpty(userid))
                    return false;

                var rolIdClaim = identity.FindFirst(ClaimTypes.Role);
                roleid = rolIdClaim?.Value;
                if (string.IsNullOrEmpty(roleid))
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
