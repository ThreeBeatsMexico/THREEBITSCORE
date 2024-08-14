using Microsoft.AspNetCore.Mvc.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Business.Filters
{
	public static class OperationFilterContextExtensions
	{

		public static CustomAttribute RequireAttribute<T>(this OperationFilterContext context) where T : ICustomAttribute
		{
			IEnumerable<IFilterMetadata> first = context.ApiDescription.ActionDescriptor.FilterDescriptors.Select((Microsoft.AspNetCore.Mvc.Filters.FilterDescriptor p) => p.Filter);
			object[] controllerAttributes = context.MethodInfo?.DeclaringType?.GetCustomAttributes(true) ?? Array.Empty<object>();
			List<T> containsHeaderAttributes = Enumerable.Union(second: context.MethodInfo?.GetCustomAttributes(true) ?? Array.Empty<object>(), first: first.Union(controllerAttributes)).OfType<T>().ToList();
			if (containsHeaderAttributes.Count != 0)
			{
				return new CustomAttribute(true, containsHeaderAttributes.First().IsMandatory);
			}
			return new CustomAttribute(false, false);
		}
	}
}
