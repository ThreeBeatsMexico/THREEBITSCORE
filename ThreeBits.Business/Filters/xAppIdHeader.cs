using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Business.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class xAppIdHeader : Attribute, ICustomAttribute, IOperationFilter
    {
        public static string HeaderName = "xAppId";
        public bool IsMandatory { get; }

        public xAppIdHeader(bool isMandatory = false)
        {
            IsMandatory = isMandatory;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            CustomAttribute xAppIdHeader = context.RequireAttribute<xAppIdHeader>();
            if (!xAppIdHeader.ContainsAttribute)
                return;


            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = HeaderName,
                In = ParameterLocation.Header,
                Required = xAppIdHeader.Mandatory,
                Schema = new OpenApiSchema() { Type = "string" }
            });
        }
    }
}
