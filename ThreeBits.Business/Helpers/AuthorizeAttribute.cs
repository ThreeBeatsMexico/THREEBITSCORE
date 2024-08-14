using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Business.Helpers
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class AuthorizeAttribute : Attribute, IAuthorizationFilter, IFilterMetadata
	{
		
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (context.HttpContext.Items["User"] == null)
			{
				context.Result = new JsonResult(new
				{
					message = "Unauthorized"
				})
				{
					StatusCode = 401
				};
			}
		}
	}
}
